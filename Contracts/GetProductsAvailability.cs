using System.Collections.Generic;

namespace Contracts
{
    public record GetProductsAvailabilityRequest
    {
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string ProductId { get; set; }

        public int Quantity { get; set; }
    }

    public record GetProductsAvailabilityResponse
    {
        public List<ProductAvailabilityResult> Results { get; set; }
    }

    public class ProductAvailabilityResult
    {
        public string ProductId { get; set; }

        public bool DoesExist { get; set; }

        public bool SufficientStock { get; set; }
    }
}
