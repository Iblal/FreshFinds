using ProductService.Entities;

namespace ProductService.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetProduct(string id);

        void CreateProduct(Product product);
    }
}
