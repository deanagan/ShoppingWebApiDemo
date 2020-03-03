using System.Collections.Generic;

using Api.Interfaces;
using Api.Models;

namespace Api.Data
{
    public class ProductRepository : IProductRepository
    {        
        private readonly List<Product> ProductsForSale = new List<Product>
        {
            new Product(12.34M, "PRODUCT_001", "Awesome product"),
            new Product(56.78M, "PRODUCT_002", "Cool product"),
            new Product(98.76M, "PRODUCT_003", "Fantastic product"),
        };

        public List<Product> GetProducts()
        {
            return ProductsForSale;
        }
    }
}