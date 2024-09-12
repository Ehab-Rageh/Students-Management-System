using Microsoft.AspNetCore.Mvc;
using Students_Management.Models;
using Students_Management.ViewModels;

namespace Students_Management.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public UserController()
        {
            this.dbContext = new();
        }
        public IActionResult Index()
        {
            List<User> users = dbContext.Users.ToList();
            return View(users);
        }

        //======================< creation >======================

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserVM uservm)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    FName = uservm.FName,
                    LName = uservm.LName,
                    DateOfBirth = uservm.DateOfBirth,
                    Email = uservm.Email,
                    Password = uservm.Password,
                    Gender = uservm.Gender,
                    Role = uservm.Role,
                };
                dbContext.Add(user);
                dbContext.SaveChanges();
                TempData["Alert"] = "User Created Successfully...!";
                return RedirectToAction("Index");
            }
            return View();
        }

        //======================< Deletion >======================

        public IActionResult Delete(int id)
        {
            User? user = dbContext.Users.SingleOrDefault(x => x.ID == id);
            if (user is null) return Content("Invaild Id");
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            TempData["Alert"] = "User Deleted Successfully...!";
            return RedirectToAction("Index");
        }

        //======================< Editing >======================

        [HttpGet]
        public IActionResult Edit(int id)
        {
            User? user = dbContext.Users.SingleOrDefault(x => x.ID == id);
            if (user is null) { return Content("Id Invaild"); }
            EditedUserVM userVM = new()
            {
                ID = user.ID,
                FName = user.FName,
                LName = user.LName,
                DateOfBirth = user.DateOfBirth,
                City = user.City,
                Street = user.Street,
                Phone = user.Phone,
                Gender = user.Gender,
                Year = (int)user.Year,
                Semester = (int)user.Semester,
                Role = user.Role
            };
            return View(userVM);
        }
        [HttpPost]
        public IActionResult Edit(EditedUserVM model)
        {
            User? user = dbContext.Users.SingleOrDefault(x => x.ID == model.ID);
            if (user is null) return Content("Invaild Id");
            {
                user.FName = model.FName;
                user.LName = model.LName;
                user.DateOfBirth = model.DateOfBirth;
                user.City = model.City;
                user.Street = model.Street;
                user.Phone = model.Phone;
                user.Gender = model.Gender;
                user.Year = model.Year;
                user.Semester = model.Semester;
                user.Role = model.Role;
            }
            dbContext.SaveChanges();
            TempData["Alert"] = "User Updated Successfully...!";
            return RedirectToAction("Index");
        }

        //======================< Details >======================

        public IActionResult Details(int id)
        {
            User? user = dbContext.Users.SingleOrDefault(u => u.ID == id);
            if (user is null) return Content("Invaild Id");
            return View(user);
        }


    }
}
