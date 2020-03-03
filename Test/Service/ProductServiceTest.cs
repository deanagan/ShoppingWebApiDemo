using Xunit;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

using Api.Models;
using Api.Services;
using Api.Controllers;
using Api.Interfaces;

namespace Test.Controller
{
    public class ProductServiceTest
    {
        private readonly List<Product> _productList = new List<Product>
        {
            new Product(1.23M, "PROD_001", "Cool 1"),
            new Product(4.56M, "PROD_002", "Awesome 2")
        };
        private readonly IProductService _productService;
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();

        public ProductServiceTest()
        {
            _productRepositoryMock.Setup(
                pr => pr.GetProducts()).Returns(_productList);
            
            _productService = new ProductService(_productRepositoryMock.Object);
        }

        [Fact]
        public void AllCodesReturned_WhenGetProductSkuCodesInvoked()
        {
            // Act
            var skuCodes = _productService.GetProductSkuCodes();

            // Assert
            skuCodes.Count.Should().Be(2);
            skuCodes.First().Should().Be("PROD_001");
            skuCodes.Last().Should().Be("PROD_002");
        }

        [Fact]
        public void CorrectProductReturned_WhenGetProductRetrievedThruSkuCode()
        {
            // Act
            var product = _productService.GetProduct("PROD_001");

            // Assert
            product.Should().Be(_productList.First());
        }

        [Fact]
        public void NullProductReturned_WhenSkuCodeDoesNotExist()
        {
            // Act
            var product = _productService.GetProduct("PROD_003");

            // Assert
            product.Should().BeNull();
        }

    }
}
