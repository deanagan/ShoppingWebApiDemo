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

            // Act
            var response = controller.AddProduct("PROD_001");

            // Assert
            response.Should().NotBeNull().And.BeOfType<OkResult>();
        }

        [Fact]
        public void RemoveCartItemReturnsSuccess_WhenRemovingSameCartItemsMultipleTimes()
        {
            // Arrange
            var cartService = Mock.Of<ICartService>();
            var controller = new CartController(cartService);
            Mock.Get(cartService).Setup(cs => cs.RemoveProduct(It.IsAny<string>())).Returns(true);

            // Act
            var response = controller.RemoveProduct("PROD_001");
            response = controller.RemoveProduct("PROD_001");

            // Assert
            // Because delete is an idempotent command, multiple deletions should always be 200/204.
            response.Should().NotBeNull().And.BeOfType<OkResult>();
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
