using Lad_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lad_02.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 500000, CreatedAt = new DateTime(2020,12,25), ImageUrl = "/images/1.png" },
                new Product { Id = 2, Name = "Product 2", Price = 700000, CreatedAt = new DateTime(2020,12,25), ImageUrl = "/images/2.png" },
                new Product { Id = 3, Name = "Product 3", Price = 550000, CreatedAt = new DateTime(2020,12,25), ImageUrl = "/images/3.png" },
                new Product { Id = 4, Name = "Product 4", Price = 550000, CreatedAt = new DateTime(2020,12,25), ImageUrl = "/images/1.png" }
            };

            return View(products);
        }
    }
}
