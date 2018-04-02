using System;
using System.Collections.Generic;

namespace SPECS_Web_Server.Models
{
    public class Family
    {
        public int ID { get; set; }
        public String name { get; set; }
        public ICollection<DevicePermission> devicePermissions { get; set; }

        public ICollection<ApplicationUser> members { get; set; }
        
    }
}