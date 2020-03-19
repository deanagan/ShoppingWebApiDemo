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
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            this.cartItemService = cartItemService;
        }

        [HttpPost("[action]")]
        public IActionResult Add([FromBody]CartItem cartItem)
        {
            cartItemService.Add(cartItem);
            return Ok();
        }

        [HttpDelete("[action]")]
        public IActionResult Remove(int id)
        {
            cartItemService.Remove(id);
            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(cartItemService.GetAll());
        }

        
    }
}
