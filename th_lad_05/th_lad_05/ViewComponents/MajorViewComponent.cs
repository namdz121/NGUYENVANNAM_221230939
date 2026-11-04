using Microsoft.AspNetCore.Mvc;
using th_lad_05.Data;
using th_lad_05.Models;

namespace th_lad_05.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        SchoolContext db;
        List<Major> majors;

        public MajorViewComponent(SchoolContext _context)
        {
            db = _context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            majors = db.Majors.ToList();
            return View("RenderMajor", majors);
        }
    }
}