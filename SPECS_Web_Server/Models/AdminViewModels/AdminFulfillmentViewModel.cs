using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPECS_Web_Server.Models.AdminViewModels
{
    public class AdminFulfillmentViewModel
    {
        public List<Fulfillment> Fulfillments { get; set; }
        public string StatusMessage { get; set; }

    }
}
