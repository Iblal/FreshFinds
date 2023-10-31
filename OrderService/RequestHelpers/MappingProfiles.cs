using AutoMapper;
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
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<OrderItem, OrderItemDto>();
        }
    }

}
