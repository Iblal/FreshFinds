using AutoMapper;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Data.Repositories;
using OrderService.DTOs;
using OrderService.Entities;
using OrderService.Services;
using OrderService.Utility;

namespace OrderService.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderController(IOrderRepository orderRepository, IMapper mapper, 
            IProductService productService, IPublishEndpoint publishEndpoint)
        {
            _repo = orderRepository;
            _mapper = mapper;
            _productService = productService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            try 
            {
                var order = _mapper.Map<Order>(createOrderDto);

                _repo.CreateOrder(order);

                var newOrder = _mapper.Map<OrderDto>(order);

                var productResults = _productService.GetProductsAvailabilityAsync(newOrder.Items);

                ProductAvailabilityHelper.CheckProductsAvailability(productResults.Result);

                await _publishEndpoint.Publish(_mapper.Map<OrderCreated>(newOrder));

                var result = await _repo.SaveChangesAsync();

                if (!result) throw new DbUpdateException("Could not persist changes");


                return Ok("Order created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create order: " + ex.Message);
            }
        }
    }
}
