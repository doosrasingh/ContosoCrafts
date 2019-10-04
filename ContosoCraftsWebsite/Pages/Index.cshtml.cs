using System.Collections.Generic;
using ContosoCraftsWebsite.Models;
using ContosoCraftsWebsite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCraftsWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ProductService { get; set; }
        public IEnumerable<Product> Products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
