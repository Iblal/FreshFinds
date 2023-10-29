using MongoDB.Entities;
using ProductService.Entities;

namespace ProductService.Data.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        public async void CreateProduct(Product product)
        {
            await product.SaveAsync();
        }

        public async Task<Product?> GetProduct(string id)
        {
            var product = await DB.Find<Product>().MatchID(id).ExecuteFirstAsync();

            return product;
        }

    }
}
