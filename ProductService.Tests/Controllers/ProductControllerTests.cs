using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductService.Controllers;
using ProductService.Data.Repositories;
using ProductService.DTOs;
using ProductService.Entities;

namespace ProductService.Tests.Controllers
{
    public sealed class ProductControllerTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void GetProduct_Should_Return_NotFound_If_Id_Is_NullOrEmpty(string id)
        {
            //Arrange
            var mockProductRepository = new Mock<IProductRepository>();

            var controller = new ProductsController(mockProductRepository.Object, null);

            // Act
            var result = await controller.GetProduct(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async void GetProduct_Should_Return_ProductDto_If_Id_Valid()
        {
            //Arrange
            var validProductId = "653e20c3394fb738aa184d7b";

            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository.Setup(repo => repo.GetProduct(validProductId))
               .ReturnsAsync(new Product());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(mapper => mapper.Map<ProductDto>(It.IsAny<Product>()))
                .Returns(new ProductDto());

            var controller = new ProductsController(mockProductRepository.Object, mockMapper.Object);

            // Act
            var result = await controller.GetProduct(validProductId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result); 
            var productResult = Assert.IsType<ProductDto>(((OkObjectResult)result.Result).Value);
        }

        [Fact]
        public async Task GetProduct_Should_Return_NotFound_If_Id_Is_Invalid()
        {
            // Arrange
            var invalidProductId = "653e20c3394fb738aa184d7a-invalid";

            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository.Setup(repo => repo.GetProduct(invalidProductId))
                .ReturnsAsync((Product)null);

            var controller = new ProductsController(mockProductRepository.Object, null);

            // Act
            var result = await controller.GetProduct(invalidProductId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateProduct_Should_Return_OkResult_On_Success()
        {
            // Arrange
            var createProductDto = new CreateProductDto();

            var mockProductRepository = new Mock<IProductRepository>();
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(mapper => mapper.Map<Product>(createProductDto))
                .Returns(new Product());

            var controller = new ProductsController(mockProductRepository.Object, mockMapper.Object);

            // Act
            var result = await controller.CreateProduct(createProductDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal("Product created successfully", okResult.Value);
        }

        [Fact]
        public async Task CreateProduct_Should_Return_BadRequest_On_Failure()
        {
            // Arrange
            var createProductDto = new CreateProductDto(); // Provide invalid DTO

            var mockProductRepository = new Mock<IProductRepository>();
            var mockMapper = new Mock<IMapper>();

            mockMapper.Setup(mapper => mapper.Map<Product>(createProductDto))
                .Throws<AutoMapperMappingException>(); // Simulate a mapping exception

            var controller = new ProductsController(mockProductRepository.Object, mockMapper.Object);

            // Act
            var result = await controller.CreateProduct(createProductDto);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.StartsWith("Failed to create product:", badRequestResult.Value.ToString());
        }

    }
}
