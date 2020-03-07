using System.Collections.Generic;

using Api.Models;
namespace Api.Interfaces
{
    public interface ICartItemRepository
    {
        List<CartItem> GetCartItems();
        CartItem GetCartItem(string skuCode);
        void AddCartItem(CartItem cartItem);
        bool RemoveItem(string skuCode);
    }
}