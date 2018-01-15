using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPECS_Web_Server.Models
{
    /// <summary>
    /// Model for proper(?) DB re-implementation
    /// </summary>
    public class User
    {
        private UserContext context;

        public int UserID { get; set; }

        public string AlexaID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Color { get; set; }

        public string DeviceIDs { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
