using System;
using System.Collections.Generic;

namespace SPECS_Web_Server.Models
{
    public class DevicePermission
    {
        public int ID { get; set; }
        public Boolean access { get; set; }
        public String deviceInfo { get; set; }
        public virtual ApplicationUser deviceOwner { get; set; }
        public  List<ApplicationUser> grantedTo { get; set; }
        public string DeviceID { get; set; }
        
    }
}