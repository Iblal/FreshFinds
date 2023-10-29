using FluentValidation.TestHelper;
using ProductService.DTOs;
using ProductService.Validations;

namespace FreshFinds.Product.API.Tests.Validations
{
    public sealed class CreateProductValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateProductValidator_Should_Throw_Exception_If_ProductName_NullOrEmpty(string name)
        {
            // Arrange
            var validator = new CreateProductValidator();
            var createProductDto = new CreateProductDto { Name = name };

            // Act
            var result = validator.TestValidate(createProductDto);

            // Assert
            result.ShouldHaveValidationErrorFor(product => product.Name);
        }
    }
}
