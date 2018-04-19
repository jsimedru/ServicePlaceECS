using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPECS_Web_Server.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2 (If Applicable)")]
        public string Address2 { get; set; }

        [Display(Name = "Medical Conditions")]
        public string MedicalConditions { get; set; }

        [Display(Name = "Preferred Doctor")]
        public string PreferredDoctor { get; set; }

        public string StatusMessage { get; set; }
    }
}
