using Xunit;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Api.Models;
using Api.Services;
using Api.Controllers;

namespace Test.Controller
{
    public class ProductControllerTest
    {
        private readonly Product _product = new Product(1.99M, "PROD_001", "Cheap Product");
        [Fact]
        public void ProductShouldBeReturned_WhenItExists()
        {
            // Arrange
            var productService = new Mock<IProductService>();
            productService.Setup(s => s.GetProduct("PROD_001")).Returns(_product);
            var controller = new ProductController(productService.Object);

            // Act
            var response = controller.GetProducts("PROD_001") as ObjectResult;

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            response.Value.Should().Be(_product);
        }
    }
}
