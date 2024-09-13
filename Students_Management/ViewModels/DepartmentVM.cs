using System.ComponentModel.DataAnnotations;

namespace Students_Management.ViewModels
{
    public class DepartmentVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "*"), MinLength(2, ErrorMessage = "Name must be more than 1 letter"), MaxLength(30, ErrorMessage = "Name must be less than 30 letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*"), MinLength(2, ErrorMessage = "Head must be more than 1 letter"), MaxLength(20, ErrorMessage = "Head must be less than 20 letters"),Display(Name = "Head of the department")]
        public string Head { get; set; }

        [Required(ErrorMessage = "*"), MinLength(2, ErrorMessage = "Name must be more than 1 letter"), MaxLength(3, ErrorMessage = "Name must be less than 4 letters")]
        public string Title { get; set; }
    }
}
