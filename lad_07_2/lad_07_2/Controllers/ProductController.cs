using lad_07_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lad_07_2.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>();
        private static List<Category> categories = new List<Category>();

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Validate SalePrice < Price * 0.9
                if (product.SalePrice >= product.Price * 0.9)
                {
                    ModelState.AddModelError("SalePrice", "Giá khuyến mãi phải nhỏ hơn giá chuẩn 10%");
                    ViewBag.Categories = categories;
                    return View(product);
                }

                products.Add(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = categories;
            return View(product);
        }
    }
}
