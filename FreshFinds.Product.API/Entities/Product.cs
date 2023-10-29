using MongoDB.Entities;

namespace ProductService.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get;  private set; }
    }
}
