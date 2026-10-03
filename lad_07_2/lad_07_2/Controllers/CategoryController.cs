using lad_07_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lad_07_2.Controllers
{
    public class CategoryController : Controller
    {
        private static List<Category> categories = new List<Category>();

        public IActionResult Index()
        {
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                categories.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
