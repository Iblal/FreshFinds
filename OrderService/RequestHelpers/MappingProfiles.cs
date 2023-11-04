using AutoMapper;
using Contracts;
using OrderService.DTOs;
using OrderService.Entities;

namespace OrderService.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Maps for Order
            CreateMap<CreateOrderDto, Order>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<OrderItemDto, OrderItem>();

            //Maps for OrderDTO
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id));
            CreateMap<OrderItem, OrderItemDto>();

            //Map for Items message
            CreateMap<OrderItemDto, Item>();

            //Map a new order to OrderCreated event
            CreateMap<OrderDto, OrderCreated>()
                .ForMember(dest => dest.OrderedProducts, opt => opt.MapFrom(src => src.Items));
            CreateMap<OrderItemDto, OrderedProduct>();
        }
    }

}
