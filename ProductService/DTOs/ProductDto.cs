using MongoDB.Bson;

namespace ProductService.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }
    }
}
