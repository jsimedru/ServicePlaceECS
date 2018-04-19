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

        public List<AlexaSession> AlexaSessions { get; set; }

        public virtual ICollection<MedicalSensorData> MedicalSensorData { get; set; }

        public virtual ICollection<Device> Devices { get; set; }

        public Family Family { get; set; }

        public virtual ICollection<Fulfillment> Fulfillments { get; set; }

        public String MedicalConditions { get; set; }

        public String PreferredDoctor { get; set; }

        public ApplicationUser(){
            Fulfillments = new List<Fulfillment>();
            AlexaSessions = new List<AlexaSession>();
            MedicalSensorData = new List<MedicalSensorData>();
        }
    }
}
