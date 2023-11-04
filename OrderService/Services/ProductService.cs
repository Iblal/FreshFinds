﻿using AutoMapper;
using Contracts;
using MassTransit;
using OrderService.DTOs;

namespace OrderService.Services
{
    public class ProductService : IProductService
    {
        private readonly IRequestClient<GetProductsAvailabilityRequest> _client;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public ProductService(IRequestClient<GetProductsAvailabilityRequest> client, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _client = client;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<List<ProductAvailabilityResult>> GetProductsAvailabilityAsync(List<OrderItemDto> orderItems)
        {
            var items = _mapper.Map<List<Item>>(orderItems);

            var response = await _client.GetResponse<GetProductsAvailabilityResponse>(
                        new GetProductsAvailabilityRequest
                        {
                            Items = items
                        });

            return response.Message.Results;
        }
    }
}
