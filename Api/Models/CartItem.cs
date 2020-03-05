using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; }
        public int ProductId { get; }

        public int Quantity { get; }

        public CartItem(int productId, int cartId, int quantity)
        {
            this.ProductId = productId;
            this.Quantity = quantity;
        }
    }
}