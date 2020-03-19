using System.Collections.Generic;
using System.Linq;

using Api.Models;
using Api.Interfaces;

namespace Api.Services
{
    public class CartItemService : ICartItemService
    {
        private ICartItemRepository cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            this.cartItemRepository = cartItemRepository;
        }

        public void Add(CartItem cartItem)
        {
            if (cartItem != null)
            {
                cartItemRepository.AddCartItem(cartItem);
            }
        }
        
        public bool Remove(int cartItemId)
        {
            var cartItems = cartItemRepository.GetCartItems();
            var cartItemToRemove = cartItems.Where(cartItem => cartItem.Id == cartItemId)
                                            .Select(c=>c)
                                            .DefaultIfEmpty(null)
                                            .First();
            return cartItemRepository.RemoveCartItem(cartItemToRemove);
        }

        public List<CartItem> GetAll()
        {
            return cartItemRepository.GetCartItems();
        }
    }
}
