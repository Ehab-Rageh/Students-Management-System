using System.ComponentModel.DataAnnotations;

namespace Students_Management.ViewModels
{
    public class DepartmentVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "*"), MinLength(2, ErrorMessage = "Name must be more than 1 letter"), MaxLength(20, ErrorMessage = "Name must be less than 20 letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*"), MinLength(2, ErrorMessage = "Head must be more than 1 letter"), MaxLength(20, ErrorMessage = "Head must be less than 20 letters"),Display(Name = "Head of the department")]
        public string Head { get; set; }
    }
}
