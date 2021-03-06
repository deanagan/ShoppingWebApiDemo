﻿using System;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllSkuCodes()
        {
            try
            {
                var productSkuCodes = productService.GetAllSkuCodes();
                return Ok(productSkuCodes);
            } catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{sku}")]
        public IActionResult GetProduct(string sku)
        {
            try
            {
                var product = productService.GetProduct(sku);
                return StatusCode(
                    product != null ? StatusCodes.Status200OK : StatusCodes.Status404NotFound,
                    product);
            } catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
