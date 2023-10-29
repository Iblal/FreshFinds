using Microsoft.AspNetCore.Mvc;
using ProductService.DTOs;
using AutoMapper;
using ProductService.Data.Repositories;
using ProductService.Entities;

namespace ProductService.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepo = productRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(string id)
        {
            try
            {
                var product = await _productRepo.GetProduct(id);

                if(product is null)
                {
                   return NotFound();
                }

                var productDto = _mapper.Map<ProductDto>(product);

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to find product: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            try
            {
                var product = _mapper.Map<Product>(createProductDto);

                _productRepo.CreateProduct(product);

                return Ok("Product created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create product: " + ex.Message);
            }
        }

    }
}
