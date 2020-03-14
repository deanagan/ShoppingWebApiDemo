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
    public class CartControllerTest
    {

        [Fact]
        public void AddCartItemReturnsOK_WhenAddingCartItem()
        {
            // Arrange
            var cartService = Mock.Of<ICartService>();
            var controller = new CartController(cartService);
            var product = Mock.Of<Product>(p => p.Id == 1 && p.Name == "PROD" && p.Price == 1.0M);

            // Act
            var response = controller.AddProduct(product);

            // Assert
            response.Should().NotBeNull().And.BeOfType<OkResult>();
        }

        [Fact]
        public void RemoveCartItemReturnsSuccess_WhenRemovingSameCartItemsMultipleTimes()
        {
            // Arrange
            var cartService = Mock.Of<ICartService>();
            var controller = new CartController(cartService);
            int productIdToRemove = 123;
            Mock.Get(cartService).Setup(cs => cs.RemoveProduct(It.IsAny<int>()))
                                 .Callback<int>((id) => productIdToRemove = id )
                                 .Returns(true);

            // Act
            var response = controller.RemoveProduct(productIdToRemove);
            response = controller.RemoveProduct(productIdToRemove);

            // Assert
            // Because delete is an idempotent command, multiple deletions should always be 200/204.
            response.Should().NotBeNull().And.BeOfType<OkResult>();
            Mock.Get(cartService).Verify(cs => cs.RemoveProduct(productIdToRemove), Times.Exactly(2));
            
        }

        [Fact]
        public void GetCartItemsRepoInvokedOnce_WhenGettingCartItemsViaController()
        {
            // Arrange
            var cartService = Mock.Of<ICartService>();
            var controller = new CartController(cartService);
            Mock.Get(cartService).Setup(cs => cs.GetCartItems()).Returns(new List<CartItem>());

            // Act
            var response = controller.GetCartItems();

            // Assert
            // Because delete is an idempotent command, multiple deletions should always be 200/204.
            response.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            Mock.Get(cartService).Verify(cs => cs.GetCartItems(), Times.Once);
        }
    }
}
