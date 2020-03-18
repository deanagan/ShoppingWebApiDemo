using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Api.Interfaces
{
    public interface IPriceRule
    {
        
        int Id { get; }
        
        decimal ComputeTotalPrice();

        int ComputeFlyBuys();
        
    }
}
