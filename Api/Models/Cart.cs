using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Api.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; }
        public List<int> CartItemIds { get; }
        public PriceRule PriceRule { get; set; }
    }
}
