using System.ComponentModel.DataAnnotations;

namespace Students_Management.ViewModels
{
    public class EditedUserVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "*"), MinLength(3, ErrorMessage = "Name must be more than 2 letters"), MaxLength(15, ErrorMessage = "Name must be less than 15 letters"), Display(Name = "First Name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "*"), MinLength(3, ErrorMessage = "Name must be more than 2 letters"), MaxLength(15, ErrorMessage = "Name must be less than 15 letters"), Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required(ErrorMessage = "*"), Display(Name = "Birth Date"), DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "*")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "*")]
        public int Role { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "*")]
        public int Year { get; set; }

        [Required(ErrorMessage = "*")]
        public int Semester { get; set; }
    }
}
