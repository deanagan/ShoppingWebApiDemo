using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{
    public interface IProductService
    {
        List<string> GetProductSkuCodes();
        Product GetProduct(string skuCode);
    }
}
