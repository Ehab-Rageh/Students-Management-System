using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Students_Management.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "*"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "*"), RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*_=+-]).{8,15}$")]
        public string Password { get; set; }
    }
}
