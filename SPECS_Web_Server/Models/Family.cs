using System;
using System.Collections.Generic;

namespace SPECS_Web_Server.Models
{
    public class Family
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public List<DevicePermission> DevicePermissions { get; set; }

        public List<ApplicationUser> Members { get; set; }
        
    }
}