using MongoDB.Entities;

namespace FreshFinds.Product.Domain.Entities
{
    public sealed class Product : Entity
    {
        public Product(string productName) 
        {
            Name = productName;
        }

        public string Name { get;  private set; }
    }
}
