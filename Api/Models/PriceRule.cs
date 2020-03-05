using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Api.Models
{
    public class PriceRule
    {
        [Key]
        public int Id { get; }

        public List<string> ApplicableProducts { get; set; }

        public int DiscountInPercent { get; set; }

    }
}