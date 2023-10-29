using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Entities;

namespace FreshFinds.Product.Domain.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        public async void CreateProduct(Entities.Product product)
        {
            await product.SaveAsync();
        }

        public async Task<Entities.Product> GetProduct(string id)
        {
            // Get the MongoDB client
            var mongoClient = new MongoClient(ConfigurationManager.AppSettings["ConnectionString"]);

            // Get the product collection
            var productCollection = mongoClient.GetDatabase("MyDatabase").GetCollection<Product>("Products");

            // Find the product by ID
            var filter = Builders<Product>.Filter.Eq("_id", id);
            var product = await productCollection.FindAsync(filter).FirstOrDefaultAsync();

            // Return the product
            return product;
        }

    }
}
