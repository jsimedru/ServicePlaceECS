using System.ComponentModel.DataAnnotations;

namespace SPECS_Web_Server.ViewModels
{
    public class CreateUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "PasswordRetype")]
        public string PasswordRetype { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
     
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public long Phone { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
    }
}