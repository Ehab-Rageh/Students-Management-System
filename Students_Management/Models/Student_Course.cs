using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students_Management.Models
{
    [PrimaryKey("CourseId", "UserId")]
    public class Student_Course
    {
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        public int? grade { get; set; }
    }
}
