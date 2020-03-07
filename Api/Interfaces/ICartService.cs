using System.Collections.Generic;
using Api.Models;

namespace Api.Interfaces
{
    public interface ICartService
    {
        void AddProduct(string skuCode);
        void RemoveProduct(string skuCode);
        List<CartItem> GetCartItems();
    }
}
