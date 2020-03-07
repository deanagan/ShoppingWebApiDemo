using System.Collections.Generic;

using Api.Interfaces;
using Api.Models;

namespace Api.Data
{
    public class CartItemRepository : ICartItemRepository
    {        
        private List<CartItem> cartItems = new List<CartItem>();
        
        public List<CartItem> GetCartItems()
        {
            return cartItems;
        }

        public CartItem GetCartItem(string skuCode)
        {
            return new CartItem(1, 1, 1);
        }

        public bool RemoveItem(string skuCode)
        {
            return false;
        }

        public void AddCartItem(CartItem cartItem)
        {
            
        }
    }
}