using Lad_02.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lad_02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product Name 1", Description = "Túi xách da cá sấu", Price = 1200000, ImageUrl = "/images/1.png" },
                new Product { Id = 2, Name = "Product Name 2", Description = "Túi đỏ vàng logo", Price = 950000, ImageUrl = "/images/2.png" },
                new Product { Id = 3, Name = "Product Name 3", Description = "Túi đen sang trọng", Price = 1100000, ImageUrl = "/images/3.png" }
            };

            return View(products); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
