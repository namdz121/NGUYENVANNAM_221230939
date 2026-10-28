using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using th_lad_03.Models;

namespace th_lad_03.Controllers
{
    public class StudentController : Controller
    {
        // Danh sách sinh viên mẫu dùng chung (static)
        private static List<Student> listStudents = new List<Student>()
        {
            new Student { Id = 1, Name = "Nguyễn Văn A", Email = "vana@gmail.com", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "Hà Nội", DateOfBorth = new DateTime(2002, 1, 1), Score = 8.5 }
        };

        private void LoadViewBags()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = Branch.IT.ToString() },
                new SelectListItem { Text = "BE", Value = Branch.BE.ToString() },
                new SelectListItem { Text = "CE", Value = Branch.CE.ToString() },
                new SelectListItem { Text = "EE", Value = Branch.EE.ToString() }
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Any() ? listStudents.Last().Id + 1 : 1;
                listStudents.Add(s);
                return RedirectToAction("Index"); // Hoặc return View("Index", listStudents);
            }

            // Nếu dữ liệu không hợp lệ, nạp lại ViewBag và render lại form nhập
            LoadViewBags();
            return View(s);
        }
    }
}
