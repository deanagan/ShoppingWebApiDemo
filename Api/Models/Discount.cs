using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Api.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; }
        public string Code {get; set; }
        public int DiscountInPercent { get; set; }
        public int PriceRuleId { get; set; }
    }
}
