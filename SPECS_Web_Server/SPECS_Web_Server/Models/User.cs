using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SPECS_Web_Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPECS_Web_Server.Models
{
    /// <summary>
    /// User Account Model
    /// </summary>
    public class User
    {

        [JsonIgnore]
        public AppDb Db { get; set; }

        public int ID { get; set; }

        public string Username { get; set; }

        //BAD -- FIX
        public string Password { get; set; }
     
        public string Email { get; set; }

        public long Phone { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public User(AppDb db = null) => Db = db;

    }
}
