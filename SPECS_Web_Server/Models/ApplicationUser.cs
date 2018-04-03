using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SPECS_Web_Server.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String City { get; set; }
        public String Country { get; set; }
        public String AlexaID { get; set; }
        public Family family { get; set; }
        public ICollection<AlexaSession> alexaSessionData { get; set; }
        public ICollection<MedicalSensorData> MedicalSensorData { get; set; }
    }
}
