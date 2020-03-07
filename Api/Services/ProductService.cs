using System.Collections.Generic;
using System.Linq;

using Api.Models;
using Api.Interfaces;

namespace Api.Services
{
    public class ProductService : IProductService
    {
        private List<Product> products;
        public ProductService(IProductRepository productRepository)
        {
            this.products = productRepository.GetProducts();
        }

        public List<string> GetAllSkuCodes()
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
