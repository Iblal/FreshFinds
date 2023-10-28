using MongoDB.Driver;
using MongoDB.Entities;

namespace FreshFinds.Product.API.Data
{
    public class DbInitializer
    {
        public static async Task InitDb(WebApplication app)
        {
            await DB.InitAsync("Product", MongoClientSettings
                .FromConnectionString("mongodb://root:mongopw@localhost"));

            await DB.Index<Domain.Entities.Product>()
                .Key(x => x.Name, KeyType.Text)
                .CreateAsync();
        }
    }
}
