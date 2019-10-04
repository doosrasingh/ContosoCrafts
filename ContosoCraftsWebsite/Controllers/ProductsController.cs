using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCraftsWebsite.Models;
using ContosoCraftsWebsite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCraftsWebsite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [Route("Rate")]
        [HttpGet]//[HttpPost] or [HttpPut] or [HttpPatch] "[FromBody]"
        public ActionResult Get(
            [FromQuery] string productId,
            [FromQuery] int rating)
        {
            ProductService.AddRating(productId, rating);
            return Ok();
        }
    }
}