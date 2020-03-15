using System.Collections.Generic;
using System.Linq;

using Api.Models;
using Api.Interfaces;

namespace Api.Services
{
    public class CartService : ICartService
    {
        private ICartItemRepository cartItemRepository;

        public CartService(IProductRepository productRepository, ICartItemRepository cartItemRepository)
        {
            this.cartItemRepository = cartItemRepository;
        }

        public void AddItem(CartItem cartItem)
        {
            if (cartItem != null)
            {
                cartItemRepository.AddCartItem(cartItem);
            }
        }
        
        public bool RemoveItem(int cartItemId)
        {
            var cartItems = cartItemRepository.GetCartItems();
            var cartItemToRemove = cartItems.Where(cartItem => cartItem.Id == cartItemId)
                                            .Select(c=>c)
                                            .DefaultIfEmpty(null)
                                            .First();
            return cartItemRepository.RemoveCartItem(cartItemToRemove);
        }

        public List<CartItem> GetCartItems()
        {
            return cartItemRepository.GetCartItems();
        }
    }
}
