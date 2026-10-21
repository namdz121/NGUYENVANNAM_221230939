using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using th_lad_02.Models;

namespace th_lad_02.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private List<MenuItem> MenuItems = new List<MenuItem>();

        public RenderViewComponent()
        {
            MenuItems = new List<MenuItem>()
            {
                new MenuItem() { Id = 1, Name = "Branches", Link = "/Student/Index" },
                new MenuItem() { Id = 2, Name = "Students", Link = "/Student/Index" },
                new MenuItem() { Id = 3, Name = "Subjects", Link = "#" },
                new MenuItem() { Id = 4, Name = "Courses", Link = "#" }
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderLeftMenu", MenuItems);
        }
    }
}