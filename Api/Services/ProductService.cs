using System.Collections.Generic;
using System.Linq;

using Api.Models;

namespace Api.Services
{
    public class ProductService
    {
        // Some static data source
        private static readonly List<Product> ProductsForSale = new List<Product>
        {
            new Product(12.34M, "PRODUCT_001", "Awesome product"),
            new Product(56.78M, "PRODUCT_002", "Cool product"),
            new Product(98.76M, "PRODUCT_003", "Fantastic product"),
        };

        private List<Product> products;
        public ProductService()
        {
            this.products = ProductsForSale;
        }

        public List<string> GetProductSkuCodes()
        {
            return products.Select(product => product.SkuCode).ToList();
        }

        public Product GetProduct(string skuCode)
        {
            return products.Where(product => product.SkuCode == skuCode)
                    .Select(matchingProduct => matchingProduct)
                    .DefaultIfEmpty(null)
                    .First();
        }

    }
}
