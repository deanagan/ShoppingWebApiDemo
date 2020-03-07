using Xunit;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

using Api.Models;
using Api.Interfaces;
using Api.Controllers;

namespace Test.Controller
{
    public class ProductControllerTest
    {
        private readonly Product _product = new Product(1.99M, "PROD_001", "Cheap Product");

        private readonly List<string> _productSkuCodes = new List<string> 
        { "PROD_001", "PROD_002", "PROD_003" };


        [Fact]
        public void ProductShouldBeReturned_WhenItExists()
        {
            // Arrange
            var productService = new Mock<IProductService>();
            productService.Setup(s => s.GetProduct("PROD_001")).Returns(_product);
            var controller = new ProductController(productService.Object);

            // Act
            var response = controller.GetProduct("PROD_001") as ObjectResult;

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            response.Value.Should().Be(_product);
        }

        [Fact]
        public void ProductListShouldBeReturned_WhenGetProductCodesInvoked()
        {
            // Arrange
            var productService = new Mock<IProductService>();
            productService.Setup(s => s.GetAllSkuCodes()).Returns(_productSkuCodes);
            var controller = new ProductController(productService.Object);

            // Act
            var response = controller.GetAllSkuCodes() as ObjectResult;

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            response.Value.Should().Be(_productSkuCodes);
        }

        [Fact]
        public void Error404Returned_WhenGettingNonExistentProduct()
        {
            var productService = new Mock<IProductService>();
            productService.Setup(s => s.GetProduct("PROD_999")).Returns(null as Product);
            var controller = new ProductController(productService.Object);

            var response = controller.GetProduct("PROD_999") as ObjectResult;

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }
    }
}
