using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using Api.Interfaces;
using Api.Models;

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
        public IActionResult AddItem([FromBody]CartItem cartItem)
        {
            cartService.AddItem(cartItem);
            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult RemoveItem(int id)
        {
            cartService.RemoveItem(id);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetCartItems()
        {
            return Ok(cartService.GetCartItems());
        }

        
    }
}
