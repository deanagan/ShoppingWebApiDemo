using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string SkuCode { get; set; }
        public string Name { get; set; }

        public Product(decimal price, string skuCode, string name)
        {
            this.Price = price;
            this.SkuCode = skuCode;
            this.Name = name;
        }
    }
}