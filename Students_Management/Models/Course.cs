using System.ComponentModel.DataAnnotations.Schema;

namespace Students_Management.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }

        public Department? Department { get; set; }
        public List<Student_Course>? Students { get; set; }

    }
}
