using Contracts;
using OrderService.Exceptions;
using OrderService.Utility;

namespace OrderService.Tests.Utility
{

    public sealed class ProductAvailabilityHelperTests
    {
        [Fact]
        public void ProductAvailabilityHelper_Should_Throw_Product_Does_Not_Exist_Exception_When_Result_DoesExist_Is_False()
        {
            //Arrange
            var productResult = new List<ProductAvailabilityResult>()
            {
                new ProductAvailabilityResult()
                {
                    ProductId = "65463e45de326a8228a5a058",
                    DoesExist = false,
                    SufficientStock = false
                }
            };

            //Act + Assert
            Assert.Throws<ProductDoesNotExistException>(() => ProductAvailabilityHelper.CheckProductsAvailability(productResult));
        }

        [Fact]
        public void ProductAvailabilityHelper_Should_Throw_Insufficent_Stock_Exception_If_Product_Stock_Insufficient()
        {
            //Arrange
            var productResult = new List<ProductAvailabilityResult>()
            {
                new ProductAvailabilityResult()
                {
                    ProductId = "65463e45de326a8228a5a058",
                    DoesExist = true,
                    SufficientStock = false
                }
            };

            //Act + Assert
            Assert.Throws<ProductInsufficientStockException>(() => ProductAvailabilityHelper.CheckProductsAvailability(productResult));
        }
    }
}
