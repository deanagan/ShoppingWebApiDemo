using System.Collections.Generic;
using System.Linq;

using Api.Models;
using Api.Interfaces;

namespace Api.Services
{
    public class CartService : ICartService
    {
        private IProductRepository productRepository;
        private ICartItemRepository cartItemRepository;

        public CartService(IProductRepository productRepository, ICartItemRepository cartItemRepository)
        {
            this.productRepository = productRepository;
            this.cartItemRepository = cartItemRepository;
        }
        public void AddProduct(string skuCode)
        {
            var product = productRepository.GetProducts()
                                        .Where(product => product.Name == skuCode)                                        
                                        .DefaultIfEmpty(null)
                                        .First();
            if (product != null)
            {
                var cartItem = new CartItem { ProductId = product.Id, Quantity = 1 };
                cartItemRepository.AddCartItem(cartItem);
            }

            
        }

        public void RemoveProduct(string skuCode)
        {

        }

        public List<CartItem> GetCartItems()
        {
            return cartItemRepository.GetCartItems();
        }

    }
}
