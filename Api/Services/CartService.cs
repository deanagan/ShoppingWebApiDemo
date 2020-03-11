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

        private Product GetProductUsingSkuCode(string skuCode)
        {
            return productRepository.GetProducts()
                                    .Where(product => product.SkuCode == skuCode)                                        
                                    .DefaultIfEmpty(null)
                                    .First();
        }
        public void AddProduct(string skuCode)
        {
            var product = GetProductUsingSkuCode(skuCode);

            if (product != null)
            {
                var cartItem = new CartItem { ProductId = product.Id, Quantity = 1 };
                cartItemRepository.AddCartItem(cartItem);
            }

            
        }

        public bool RemoveProduct(string skuCode)
        {
            var product = GetProductUsingSkuCode(skuCode);
            if (product == null)
            {
                return false;
            }
            var cartItems = cartItemRepository.GetCartItems();
            var cartItemToRemove = cartItems.Where(ci => ci.ProductId == product.Id).First();
            return cartItemRepository.RemoveCartItem(cartItemToRemove);
        }

        public List<CartItem> GetCartItems()
        {
            return cartItemRepository.GetCartItems();
        }

    }
}
