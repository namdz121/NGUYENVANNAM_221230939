using Microsoft.AspNetCore.Mvc;

namespace Lad_02.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
