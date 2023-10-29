
namespace FreshFinds.Product.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Entities.Product> GetProduct(string id);

        void CreateProduct(Entities.Product product);
    }
}
