using MongoDB.Driver;
using MongoDB.Entities;
using ProductService.Entities;

namespace ProductService.Data
{
    public class DbInitializer
    {
        public static async Task InitDb(WebApplication app)
        {
            await DB.InitAsync("Product", MongoClientSettings
                .FromConnectionString("mongodb://root:mongopw@localhost"));

            await DB.Index<Product>()
                .Key(x => x.Name, KeyType.Text)
                .CreateAsync();
        }
    }
}
