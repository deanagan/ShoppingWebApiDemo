using System.Collections.Generic;
using Api.Models;

namespace Api.Interfaces
{
    public interface ICartService
    {
        void AddProduct(string skuCode);
        bool RemoveProduct(string skuCode);
        List<CartItem> GetCartItems();
    }
}
