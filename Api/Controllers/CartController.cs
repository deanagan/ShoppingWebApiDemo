using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using Api.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpPost("[action]")]
        public IActionResult AddProduct([FromBody]string skuCode)
        {
            cartService.AddProduct(skuCode);
            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult RemoveProduct(string skuCode)
        {
            cartService.RemoveProduct(skuCode);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetCartItems()
        {
            return Ok(cartService.GetCartItems());
        }

        
    }
}
