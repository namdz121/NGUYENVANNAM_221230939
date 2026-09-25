using Lad_06.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Lad_06.Controllers
{
    public class MemberController : Controller
    {
        // Danh sách static để lưu tạm
        private static readonly List<Member> members = new List<Member>
        {
            new Member{MemberId = Guid.NewGuid().ToString(), Username = "member1", Fullname = "Thành viên 1", Password ="123456", Email = "tv1@gmail.com"},
            new Member{MemberId = Guid.NewGuid().ToString(), Username = "member2", Fullname = "Thành viên 2", Password ="123456", Email = "tv2@gmail.com"},
            new Member{MemberId = Guid.NewGuid().ToString(), Username = "member3", Fullname = "Thành viên 3", Password ="123456", Email = "tv3@gmail.com"},
            new Member{MemberId = Guid.NewGuid().ToString(), Username = "member4", Fullname = "Thành viên 4", Password ="123456", Email = "tv4@gmail.com"},
            new Member{MemberId = Guid.NewGuid().ToString(), Username = "member5", Fullname = "Thành viên 5", Password ="123456", Email = "tv5@gmail.com"},
        };

        public IActionResult Index()
        {
            var member = new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "nguyenvannam",
                Fullname = "Nguyen Van Nam",
                Password = "password",
                Email = "namn@gmail.com"
            };

            return View(member);
        }

        public IActionResult GetMembers()
        {
            return View(members); // dùng danh sách static đã khai báo ở trên
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            member.MemberId = Guid.NewGuid().ToString();
            members.Add(member); // thêm vào danh sách static
            return RedirectToAction("GetMembers");
        }
    }
}
