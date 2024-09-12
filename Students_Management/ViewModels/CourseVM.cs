using System.ComponentModel.DataAnnotations;

namespace Students_Management.ViewModels
{
    public class CourseVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "*"), MinLength(3, ErrorMessage = "Name must be more than 2 letters"), MaxLength(15, ErrorMessage = "Name must be less than 15 letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*"), MinLength(10, ErrorMessage = "Description must be more than 10 letters"), MaxLength(150, ErrorMessage = "Description must be less than 150 letters")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "*")]
        public int Hours { get; set; }

        [Required(ErrorMessage = "*")]
        public int Year { get; set; }

        [Required(ErrorMessage = "*")]
        public int Semester { get; set; }
    }
}
