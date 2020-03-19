using System.Collections.Generic;
using Api.Models;

namespace Api.Interfaces
{
    public interface ICartItemService
    {
        void Add(CartItem cartItem);
        bool Remove(int cartItemId);
        List<CartItem> GetAll();
    }
}
