using Microsoft.AspNetCore.Mvc;
using Students_Management.Models;
using Students_Management.ViewModels;

namespace Students_Management.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public CourseController()
        {
            this.dbContext = new();
        }
        public IActionResult Index()
        {
            List<Course> courses = dbContext.Courses.ToList();
            return View(courses);
        }

        //======================< creation >======================

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseVM coursevm)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course()
                {
                    Name = coursevm.Name,
                    Description = coursevm.Description,
                    Hours = coursevm.Hours,
                    Year = coursevm.Year,
                    Semester = coursevm.Semester
                };
                dbContext.Add(course);
                dbContext.SaveChanges();
                TempData["Alert"] = "Course Created Successfully...!";
                return RedirectToAction("Index");
            }
            return View();
        }

        //======================< Deletion >======================

        public IActionResult Delete(int id)
        {
            Course? course = dbContext.Courses.SingleOrDefault(x => x.ID == id);
            if (course is null) return Content("Invaild Id");
            dbContext.Courses.Remove(course);
            dbContext.SaveChanges();
            TempData["Alert"] = "Course Deleted Successfully...!";
            return RedirectToAction("Index");
        }

        //======================< Editing >======================

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course? course = dbContext.Courses.SingleOrDefault(x => x.ID == id);
            if (course is null) return Content("Invaild Id");
            CourseVM courseVM = new()
            {
                ID = id,
                Name = course.Name,
                Description= course.Description,
                Hours = course.Hours,
                Year = course.Year,
                Semester = course.Semester
            };
            return View(courseVM);
        }
        [HttpPost]
        public IActionResult Edit(CourseVM model)
        {
            Course? course = dbContext.Courses.SingleOrDefault(x => x.ID == model.ID);
            if (course is null) return Content("Invaild Id");
            {
                course.Name = model.Name;
                course.Description = model.Description;
                course.Hours = model.Hours;
                course.Year = model.Year;
                course.Semester = model.Semester;
            }
            dbContext.SaveChanges();
            TempData["Alert"] = "Course Updated Successfully...!";
            return RedirectToAction("Index");
        }
    }
}
