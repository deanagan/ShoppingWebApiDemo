using System.Collections.Generic;
using Api.Models;

namespace Api.Interfaces
{
    public interface ICartService
    {
        void AddProduct(Product product);
        bool RemoveProduct(int productId);
        List<CartItem> GetCartItems();
    }
}
