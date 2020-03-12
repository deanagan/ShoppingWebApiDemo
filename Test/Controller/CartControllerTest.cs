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
        public void AddCartItemRetusOK_WhenAddingCartItem()
        {
            // Arrange
            var cartService = Mock.Of<ICartService>();
            var controller = new CartController(cartService);

            // Act
            var response = controller.AddProduct("PROD_001");

            // Assert
            response.Should().NotBeNull().And.BeOfType<OkResult>();
        }

     
    }
}
