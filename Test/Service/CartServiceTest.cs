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
        private ICartService _cartService;
        private CartItem _cartItem;
        private readonly ICartItemRepository _cartItemRepository;

        public CartServiceTest()
        {
            _cartItemRepository = Mock.Of<ICartItemRepository>(
                cir =>
                    cir.GetCartItem(1) == Mock.Of<CartItem>(ci => ci.Id == 101 && 
                                                            ci.ProductId == 1 && 
                                                            ci.Quantity == 1)
                    
            );

            _cartItem = Mock.Of<CartItem>(ci => ci.Id == 102 && 
                                          ci.ProductId == 2 && 
                                          ci.Quantity == 1);
        }

        [Fact]
        public void CartItemRepoAddCartItemInvoked_WhenAddingToCart()
        {
            // Arrange
            _cartService = new CartService(_cartItemRepository);
            
            // Act
            _cartService.AddItem(_cartItem);

            // Assert
            Mock.Get(_cartItemRepository).Verify(cir => cir.AddCartItem(_cartItem), Times.Once);
        }

        [Fact]
        public void GetCartItemsInvokesCartItemRepo_WhenGettingCartItems()
        {
            // Arrange
            _cartService = new CartService(_cartItemRepository);

            // Act
            var items = _cartService.GetCartItems();

            // Assert
            Mock.Get(_cartItemRepository).Verify(pr => pr.GetCartItems(), Times.Once);
        }

        [Fact]
        public void AddCartItemInvokedWithRightProduct_WhenAddingToCart()
        {
            // Arrange
            //_cartService = new CartService(_productRepository, _cartItemRepository);
            
            // Act
            //_cartService.AddProduct(_products.First());

            // Assert
            // Mock.Get(_cartItemRepository).Verify(cir => 
            //     cir.AddCartItem(It.Is<CartItem>(ci => ci.ProductId == _products.First().Id)), Times.Once);
        }


        [Fact]
        public void YieldsCorrectCount_WhenAddMultipleProductsToCart()
        {
            // // Arrange
            // var cartItems = new List<CartItem>();
            // _cartService = new CartService(_productRepository, _cartItemRepository);
            // Mock.Get(_cartItemRepository).Setup(ci => ci.AddCartItem(It.IsAny<CartItem>()))
            //                              .Callback<CartItem>((ci) => cartItems.Add(ci));
            // Mock.Get(_cartItemRepository).Setup(ci => ci.GetCartItems())
            //                              .Returns(cartItems);
            
            // // Act
            // _cartService.AddProduct(_products.First());
            // _cartService.AddProduct(_products.Last());

            // // Assert
            // _cartService.GetCartItems().Count.Should().Be(2);
        }

        [Fact]
        public void YieldsCorrectCount_WhenAddingMultipleProductsThenRemovingOneFromCart()
        {
            // Arrange
            // var dummyCartItems = new List<CartItem>();
            // _cartService = new CartService(_productRepository, _cartItemRepository);
            // Mock.Get(_cartItemRepository).Setup(ci => ci.AddCartItem(It.IsAny<CartItem>()))
            //                              .Callback<CartItem>((ci) => dummyCartItems.Add(ci));
            // Mock.Get(_cartItemRepository).Setup(ci => ci.RemoveCartItem(It.IsAny<CartItem>()))
            //                              .Callback<CartItem>((ci) => dummyCartItems.Remove(ci))
            //                              .Returns(true);
            // Mock.Get(_cartItemRepository).Setup(ci => ci.GetCartItems())
            //                              .Returns(dummyCartItems);
            
            // // Act
            // _products.ForEach(p => _cartService.AddProduct(p));
            // _cartService.RemoveProduct(_products.First().Id);
            // var cartItems = _cartService.GetCartItems();

            // // Assert
            // cartItems.Count.Should().Be(1);
            // cartItems.Should().Contain(ci => ci.ProductId == 102);
        }
    }
}
