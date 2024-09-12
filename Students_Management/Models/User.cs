using System.ComponentModel.DataAnnotations.Schema;

namespace Students_Management.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? City { get; set; } 
        public string? Street { get; set; }
        public string? Phone { get; set; }
        public string Gender { get; set; }
        public int? Year { get; set; } = 0;
        public int? Semester { get; set; } = 0;
        public int Role { get; set; }
        public List<Student_Course>? Courses { get; set; }  
        public List<Department_Instructor>? Departments { get; set; }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - DateOfBirth.Year;
                return age;
            }
        }
    }
}
