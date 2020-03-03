using System.Collections.Generic;
using Api.Models;

namespace Api.Interfaces
{
    public interface IProductService
    {
        List<string> GetProductSkuCodes();
        Product GetProduct(string skuCode);
    }
}
