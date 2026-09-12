using lad_04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lad_04.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();

        public IActionResult Index()
        {
            ViewBag.authors = new SelectList(book.Authors, "Value", "Text");
            ViewBag.genres = new SelectList(book.Genres, "Value", "Text");

            var books = book.GetBookList();
            return View(books);
        }
    }
}
