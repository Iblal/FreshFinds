using Contracts;
using OrderService.Exceptions;

namespace OrderService.Utility
{
    public sealed class ProductAvailabilityHelper
    {
        public static void CheckProductsAvailability(List<ProductAvailabilityResult> productResults)
        {
            foreach (var product in productResults)
            {
                if (!product.DoesExist)
                {
                    throw new ProductDoesNotExistException(product.ProductId);
                }

                if (!product.SufficientStock)
                {
                    throw new ProductInsufficientStockException(product.ProductId);
                }
            }
        }
    }
}
