using FluentValidation.TestHelper;
using OrderService.DTOs;
using OrderService.Validations;

namespace OrderService.Tests.Validations
{
    public sealed class CreateOrderValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateOrderValidator_Should_Throw_Exception_If_CustomerId_NullOrEmpty(string id)
        {
            // Arrange
            var validator = new CreateOrderValidator();
            var createOrderDto = new CreateOrderDto { CustomerId = id };

            // Act
            var result = validator.TestValidate(createOrderDto);

            // Assert
            result.ShouldHaveValidationErrorFor(order => order.CustomerId);
        }

        [Fact]
        public void CreateOrderValidator_Should_Throw_Exception_If_CustomerId_Not_36_Characters()
        {
            // Arrange
            var validator = new CreateOrderValidator();
            var customerId = "00000000-0000-0000-0000-00000000000";
            var createOrderDto = new CreateOrderDto { CustomerId = customerId };

            // Act
            var result = validator.TestValidate(createOrderDto);

            // Assert
            result.ShouldHaveValidationErrorFor(order => order.CustomerId);
        }

        [Fact]
        public void CreateOrderValdiator_Should_Throw_Exception_If_OrderItems_Null()
        {
            // Arrange
            var validator = new CreateOrderValidator();
            var createOrderDto = new CreateOrderDto { CustomerId = "18a69777-0a42-4d40-b0ea-0c3109994809", Items = null };

            // Act
            var result = validator.TestValidate(createOrderDto);

            // Assert
            result.ShouldHaveValidationErrorFor(order => order.Items);
        }
    }
}
