using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPECS_Web_Server.Models.ManageViewModels
{
    public class AddDeviceViewModel
    {
        public string newToken { get; set; }

        public string deviceName { get; set; }
    }
}
