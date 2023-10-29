using MongoDB.Entities;

namespace ProductService.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get;  private set; }

        public string Description { get; private set; }

        public int Stock { get; private set; }

    }
}
