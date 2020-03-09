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
    public class CartServiceTest
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product{Id = 101, Price = 1.23M, SkuCode = "PROD_001", Name = "Cool 1"},
            new Product{Id = 102, Price = 4.56M, SkuCode = "PROD_002", Name = "Awesome 2"},
        };

        private readonly List<CartItem> _cartItems = new List<CartItem>
        {
            new CartItem{ Id = 1, ProductId = 1, Quantity = 1},
        };
        private ICartService _cartService;
        private readonly IProductRepository _productRepository;
        private readonly ICartItemRepository _cartItemRepository;

        public CartServiceTest()
        {
            _productRepository = Mock.Of<IProductRepository>(
                pr => 
                    pr.GetProducts() == _products
            );

            _cartItemRepository = Mock.Of<ICartItemRepository>(
                cir =>
                    cir.GetCartItem(1) == Mock.Of<CartItem>(ci => ci.Id == 1 && 
                                                            ci.ProductId == 1 && 
                                                            ci.Quantity == 1) &&
                    cir.GetCartItems() == _cartItems
            );
        }

        [Fact]
        public void AddedProductFound_WhenAddedToCart()
        {
            // Arrange
            _cartService = new CartService(_productRepository, _cartItemRepository);

            // Act
            _cartService.AddProduct("PROD_001");
            var cartItems = _cartService.GetCartItems();

            // Assert
            cartItems.Should().Contain(cartItem => cartItem.ProductId == 101);
        }
    }
}