using Microsoft.AspNetCore.Mvc;

namespace Lad_03.Controllers
{
    public class NamAboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Nguyễn Văn Nam";

            ViewData["classes"] = "LTW2";
            TempData["module"] = "lad 3";
            return View();
        }
    }
}
