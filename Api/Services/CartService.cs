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

        public void AddProduct(Product product)
        {
            if (product != null)
            {
                var cartItem = new CartItem { ProductId = product.Id, Quantity = 1 };
                cartItemRepository.AddCartItem(cartItem);
            }  
        }

        public bool RemoveProduct(int productId)
        {
            var product = productRepository.GetProducts()
                                    .Where(product => product.Id == productId)                                        
                                    .DefaultIfEmpty(null)
                                    .First();
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
