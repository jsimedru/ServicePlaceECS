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
    public class Family
    {

        [JsonIgnore]
        public AppDb Db { get; set; }

        public long ID { get; set; }

        public string Name { get; set; }

        public List<User> Members { get; set; }

        public Family(AppDb db = null) => Db = db;

    }
}
