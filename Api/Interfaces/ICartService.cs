using System.Collections.Generic;
using Api.Models;

namespace Api.Interfaces
{
    public interface ICartService
    {
        void AddItem(CartItem cartItem);
        bool RemoveItem(int cartItemId);
        List<CartItem> GetCartItems();
    }
}
