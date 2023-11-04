namespace OrderService.Exceptions
{
    public class ProductDoesNotExistException : Exception
    {
        public ProductDoesNotExistException(string productId)
            : base($"Product with ID {productId} does not exist.")
        {
        }
    }

    public class ProductInsufficientStockException : Exception
    {
        public ProductInsufficientStockException(string productId)
            : base($"Insufficient stock for product with ID {productId}.")
        {
        }
    }
}
