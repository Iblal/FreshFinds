using FreshFinds.Product.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FreshFinds.Product.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        public static Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto productDto)
        { 
            return null;
        }
    }
}
