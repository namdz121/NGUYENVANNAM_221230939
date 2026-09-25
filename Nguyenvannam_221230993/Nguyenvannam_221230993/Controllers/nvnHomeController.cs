using Microsoft.AspNetCore.Mvc;

namespace Nguyenvannam_221230993.Controllers
{
    public class hvtHomeController : Controller
    {
        public IActionResult nvnIndex()
        {
            return View();
        }

        public IActionResult nvnAbout()
        {
            return View();
        }

        public IActionResult nvnContact()
        {
            return View();
        }
    }
}
