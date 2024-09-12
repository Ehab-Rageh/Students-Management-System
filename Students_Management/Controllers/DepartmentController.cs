using Microsoft.AspNetCore.Mvc;
using Students_Management.Models;
using Students_Management.ViewModels;

namespace Students_Management.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public DepartmentController()
        {
            this.dbContext = new();
        }
        public IActionResult Index()
        {
            List<Department> departments = dbContext.Departments.ToList();
            return View(departments);
        }

        //======================< creation >======================

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM departmentvm)
        {
            if (ModelState.IsValid)
            {
                Department department = new Department()
                {
                    Name = departmentvm.Name,
                    Head = departmentvm.Head
                };
                dbContext.Add(department);
                dbContext.SaveChanges();
                TempData["Alert"] = "Department Created Successfully...!";
                return RedirectToAction("Index");
            }
            return View();
        }

        //======================< Deletion >======================

        public IActionResult Delete(int id)
        {
            Department? department = dbContext.Departments.SingleOrDefault(x => x.ID == id);
            if (department is null) return Content("Invaild Id");
            dbContext.Departments.Remove(department);
            dbContext.SaveChanges();
            TempData["Alert"] = "Department Deleted Successfully...!";
            return RedirectToAction("Index");
        }

        //======================< Editing >======================

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Department? department = dbContext.Departments.SingleOrDefault(x => x.ID == id);
            if (department is null) return Content("Invaild Id");
            DepartmentVM departmentVM = new()
            {
                ID = id,
                Name = department.Name,
                Head = department.Head
            };
            return View(departmentVM);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM model)
        {
            Department? department = dbContext.Departments.SingleOrDefault(x => x.ID == model.ID);
            if (department is null) return Content("Invaild Id");
            department.Name = model.Name;
            department.Head = model.Head;
            dbContext.SaveChanges();
            TempData["Alert"] = "Department Updated Successfully...!";
            return RedirectToAction("Index");
        }
    }
}
