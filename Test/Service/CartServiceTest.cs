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
        public void AddCartItemInvokedWithMatchingCartItem_WhenAddingToCart()
        {
            // Arrange
            _cartService = new CartService(_cartItemRepository);
            
            // Act
            _cartService.AddItem(_cartItem);

            // Assert
            Mock.Get(_cartItemRepository).Verify(cir => 
                cir.AddCartItem(It.Is<CartItem>(ci => ci.ProductId == _cartItem.ProductId)), Times.Once);
        }


        [Fact]
        public void YieldsCorrectCount_WhenAddMultipleProductsToCart()
        {
            // Arrange
            var cartItemsAdded = new List<CartItem>();
            _cartService = new CartService(_cartItemRepository);
            var cartItem1 = Mock.Of<CartItem>(ci => ci.Id == 1 && 
                                              ci.Quantity == 1 && 
                                              ci.ProductId == 101);
            var cartItem2 = Mock.Of<CartItem>(ci => ci.Id == 2 && 
                                              ci.Quantity == 1 && 
                                              ci.ProductId == 102);
            
            // Act
            _cartService.AddItem(cartItem1);
            _cartService.AddItem(cartItem2);

            // Assert
            Mock.Get(_cartItemRepository).Verify(cir => cir.AddCartItem(cartItem1), Times.Once());
            Mock.Get(_cartItemRepository).Verify(cir => cir.AddCartItem(cartItem2), Times.Once());
        }

        [Fact]
        public void YieldsCorrectRemainingItem_WhenAddingMultipleProductsThenRemovingOneFromCart()
        {
            // Arrange
            var cartItemsAdded = new List<CartItem>();
            _cartService = new CartService(_cartItemRepository);
            var cartItem1 = Mock.Of<CartItem>(ci => ci.Id == 1 && 
                                              ci.Quantity == 1 && 
                                              ci.ProductId == 101);
            var cartItem2 = Mock.Of<CartItem>(ci => ci.Id == 2 && 
                                              ci.Quantity == 1 && 
                                              ci.ProductId == 102);

            Mock.Get(_cartItemRepository).Setup(cir => cir.AddCartItem(It.IsAny<CartItem>()))
                                         .Callback<CartItem>(ci => cartItemsAdded.Add(ci));
            Mock.Get(_cartItemRepository).Setup(cir => cir.RemoveCartItem(It.IsAny<CartItem>()))
                                         .Callback<CartItem>(ci => cartItemsAdded.Remove(ci));
            Mock.Get(_cartItemRepository).Setup(cir => cir.GetCartItems())
                                         .Returns(cartItemsAdded);
            
            // Act
            _cartService.AddItem(cartItem1);
            _cartService.AddItem(cartItem2);
            _cartService.RemoveItem(cartItem2.Id);

            // Assert
            Mock.Get(_cartItemRepository).Verify(cir => cir.AddCartItem(cartItem1), Times.Once());
            Mock.Get(_cartItemRepository).Verify(cir => cir.AddCartItem(cartItem2), Times.Once());
            cartItemsAdded.Should().ContainSingle(ci => ci == cartItem1);
        }
        
    }
}
