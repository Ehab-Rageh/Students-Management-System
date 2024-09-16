using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<Course> courses = dbContext.Courses.Include(x=>x.Department).ToList();
            return View(courses);
        }

        //======================< creation >======================

        [HttpGet]
        public IActionResult Create()
        {
            List<Department> departments = dbContext.Departments.ToList();
            List<User> instructors = dbContext.Users.Where(x=>x.Role == 2).ToList();
            CourseVM courseVM = new CourseVM()
            {
                departments = departments,
                instructors = instructors
            };
            return View(courseVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
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
                    Semester = coursevm.Semester,
                    DepartmentID = coursevm.DepartmentID,
                    Department = dbContext.Departments.SingleOrDefault(x => x.ID == coursevm.DepartmentID),
                    InstructorID = coursevm.InstructorID,
                    Instructor = dbContext.Users.SingleOrDefault(x => x.ID == coursevm.InstructorID && x.Role == 2)
                };
                if (course.Department is null) return Content("Wrong Department");
                if (course.Instructor is null) return Content("Wrong Instructor");
                dbContext.Add(course);
                dbContext.SaveChanges();
                TempData["Alert"] = "Course Created Successfully...!";
                return RedirectToAction("Index");
            }
            return View(coursevm);
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
            List<User>? instructors = dbContext.Users.Include(x => x.Department).Where(x => x.Role == 2).ToList();
            Course? course = dbContext.Courses.SingleOrDefault(x => x.ID == id);
            if (course is null) return Content("Invaild Id");
            if (instructors is null) return Content("Invaild instructors");
            CourseVM courseVM = new()
            {
                ID = id,
                Name = course.Name,
                Description= course.Description,
                Hours = course.Hours,
                Year = course.Year,
                Semester = course.Semester,
                DepartmentID = course.DepartmentID,
                InstructorID = course.InstructorID,
                instructors = instructors
            };
            return View(courseVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
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
                course.DepartmentID = model.DepartmentID;
                course.Department = dbContext.Departments.SingleOrDefault(x => x.ID == model.DepartmentID);
                course.InstructorID = model.InstructorID;
                course.Instructor = dbContext.Users.SingleOrDefault(x => x.Role == 2 && x.ID == model.InstructorID);
            }
            dbContext.SaveChanges();
            TempData["Alert"] = "Course Updated Successfully...!";
            return RedirectToAction("Index");
        }

        //======================< Details >======================

        public IActionResult Details(int id)
        {
            Course? course = dbContext.Courses.Include(x => x.Department).Include(x=>x.Instructor).SingleOrDefault(x => x.ID == id);
            if (course is null) return Content("Invaild Id");
            return View(course);
        }
    }
}

