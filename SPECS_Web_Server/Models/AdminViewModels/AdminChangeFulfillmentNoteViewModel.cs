using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPECS_Web_Server.Models.AdminViewModels
{
    public class AdminChangeFulfillmentNoteViewModel
    {
        public int FulfillmentID { get; set; }
        public string CurrentNote { get; set; }
        public string Note { get; set; }
        public string StatusMessage { get; set; }

    }
}
