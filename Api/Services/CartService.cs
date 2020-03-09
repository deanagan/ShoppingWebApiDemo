using System.Collections.Generic;
using System.Linq;

using Api.Models;
using Api.Interfaces;

namespace Api.Services
{
    public class CartService : ICartService
    {
        private List<Product> products;
        private IProductRepository productRepository;
        private ICartItemRepository cartItemRepository;

        public CartService(IProductRepository productRepository, ICartItemRepository cartItemRepository)
        {
            this.productRepository = productRepository;
            this.cartItemRepository = cartItemRepository;
        }
        public void AddProduct(string skuCode)
        {
            CartItem cartItem = new CartItem{Id = 1, ProductId = 1, Quantity = 1};
            cartItemRepository.AddCartItem(cartItem);
        }

        public void RemoveProduct(string skuCode)
        {

        }

        public List<CartItem> GetCartItems()
        {
            return new List<CartItem>();
        }

    }
}
