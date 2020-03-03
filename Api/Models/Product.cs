namespace Api.Models
{
    public class Product
    {
        // We should consider price in cents and or a money class. For demo, 
        // I think decimal is ok.
        public decimal Price { get; }
        public string SkuCode { get; }
        public string Name { get; }

        public Product(decimal price, string skuCode, string name)
        {
            this.Price = price;
            this.SkuCode = skuCode;
            this.Name = name;
        }
    }
}