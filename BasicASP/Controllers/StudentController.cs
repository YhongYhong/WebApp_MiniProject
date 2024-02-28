using BasicASP.Data;
using BasicASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> s1 = _db.Students;
            return View(s1);
        }
        public IActionResult Details()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(Student obj)
        {
            var isEmailExisted = _db.Students.Any(s => s.Email == obj.Email);
            if (ModelState.IsValid && !isEmailExisted)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (isEmailExisted){ ModelState.AddModelError("Email", "Email already used."); }
            return View(obj);
        }
        public IActionResult ShowScore(int id)
        {
            return Content($"คะแนนของเลขที่ {id}");
        }
    }
}
