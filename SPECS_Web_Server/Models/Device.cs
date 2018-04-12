using System;
using System.Collections.Generic;

namespace SPECS_Web_Server.Models
{
    public class Device
    {
        public int ID { get; set; }
        public String DeviceName { get; set; }
        public ApplicationUser DeviceOwner { get; set; }
        public DevicePermission DevicePermissions { get; set; }
        public string DeviceID { get; set; }
        
    }
}