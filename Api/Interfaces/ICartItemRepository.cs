using System.Collections.Generic;

using Api.Models;
namespace Api.Interfaces
{
    public interface ICartItemRepository
    {
        List<CartItem> GetCartItems();
        CartItem GetCartItem(int id);
        void AddCartItem(CartItem cartItem);
        bool RemoveCartItem(CartItem cartItem);
    }
}