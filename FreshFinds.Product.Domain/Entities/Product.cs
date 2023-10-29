using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Entities;

namespace FreshFinds.Product.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get;  private set; }
    }
}
