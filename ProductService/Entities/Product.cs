using MongoDB.Entities;

namespace ProductService.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get;  set; }

        public string Description { get; set; }

        public int Stock { get;  set; }

    }
}
