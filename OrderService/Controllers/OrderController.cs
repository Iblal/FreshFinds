using AutoMapper;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using OrderService.Data.Repositories;
using OrderService.DTOs;
using OrderService.Entities;

namespace OrderService.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderController(IOrderRepository orderRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _repo = orderRepository;
            _mapper = mapper;
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

                await _publishEndpoint.Publish(_mapper.Map<OrderCreatedEvent>(newOrder));

                var result = await _repo.SaveChangesAsync();

                if (!result) return BadRequest("Could not save changes to the DB");

                return Ok("Order created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create order: " + ex.Message);
            }
        }


    }
}
