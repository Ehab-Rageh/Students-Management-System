using Microsoft.AspNetCore.Mvc;
using Students_Management.Models;
using Students_Management.ViewModels;

namespace Students_Management.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public LoginController()
        {
            this.dbContext = new();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(LoginVM model)
        {
            User? user = dbContext.Users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null || !ModelState.IsValid) {
                ViewBag.error = "Invalid Email or Password";
                return View(nameof(Index));
            }

            HttpContext.Session.SetString("UserName", user.FName);
            HttpContext.Session.SetInt32("UserId", user.ID);
            HttpContext.Session.SetInt32("UserRole", user.Role);

            if (user.Role == 1) return RedirectToAction("Student_Details", "User", new {Id = user.ID});
            else if (user.Role == 2) return RedirectToAction("Instructor_Details", "User", new { Id = user.ID });

            return RedirectToAction(nameof(Index),"User");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

    }
}
