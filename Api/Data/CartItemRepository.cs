using System.Collections.Generic;
using System.Linq;

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

        public CartItem GetCartItem(int id)
        {
            return cartItems.Where(ci => ci.Id == id).DefaultIfEmpty(null).First();
        }

        public bool RemoveCartItem(CartItem cartItem)
        {
            return cartItems.Remove(cartItem);
        }

        public void AddCartItem(CartItem cartItem)
        {
            cartItems.Add(cartItem);
        }
    }
}