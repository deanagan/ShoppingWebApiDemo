using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; }
        public string UserName { get;set; }
        public int CartId { get;set; }

        public string MemberLevel { get; set; }        
    }
}
