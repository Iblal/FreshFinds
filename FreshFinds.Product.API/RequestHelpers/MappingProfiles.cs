using AutoMapper;
using ProductService.DTOs;
using ProductService.Entities;

namespace ProductService.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<CreateProductDto, Product>();

            CreateMap<Product, ProductDto>();
        }
    }
}
