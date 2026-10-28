
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using th_lad_04.Data;
using th_lad_04.Models;

namespace th_lad_04.Controllers
{
    public class LearnerController : Controller
    {
        private readonly SchoolContext db;

        public LearnerController(SchoolContext context)
        {
            db = context;
        }

        // 1. Hiển thị danh sách (Index)[cite: 22, 23]
        public IActionResult Index()
        {
            var learners = db.Learners.Include(m => m.Major).ToList();
            return View(learners);
        }

        // 2. Thêm mới - GET[cite: 25, 26]
        public IActionResult Create()
        {
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        // 2. Thêm mới - POST[cite: 25, 26]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        // 3. Chỉnh sửa - GET[cite: 31]
        public IActionResult Edit(int? id)
        {
            if (id == null || db.Learners == null) return NotFound();
            var learner = db.Learners.Find(id);
            if (learner == null) return NotFound();

            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        // 3. Chỉnh sửa - POST[cite: 31, 32]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (id != learner.LearnerID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!db.Learners.Any(e => e.LearnerID == learner.LearnerID)) return NotFound();
                    else throw;
                }
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        // 4. Xóa - GET[cite: 36, 37]
        public IActionResult Delete(int? id)
        {
            if (id == null || db.Learners == null) return NotFound();

            var learner = db.Learners
                .Include(l => l.Major)
                .Include(l => l.Enrollments)
                .FirstOrDefault(m => m.LearnerID == id);

            if (learner == null) return NotFound();

            // Ràng buộc: Nếu học viên đã có bản ghi đăng ký môn học thì không cho xóa[cite: 37, 39]
            if (learner.Enrollments.Count > 0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }

            return View(learner);
        }

        // 4. Xóa - POST[cite: 36, 37]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Learners == null) return Problem("Entity set 'Learners' is null.");
            var learner = db.Learners.Find(id);
            if (learner != null)
            {
                db.Learners.Remove(learner);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
