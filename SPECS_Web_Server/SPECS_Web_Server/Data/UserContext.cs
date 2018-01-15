using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SPECS_Web_Server.Models
{
    /// <summary>
    /// Initial DB re-implementation using a proper(?) MVC architecture
    /// </summary>
    public class UserContext
    {
        public string ConnectionString { get; set; }

        public UserContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();

            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM user_data", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            AlexaID = reader.GetString("id_alexa"),
                            DeviceIDs = reader.GetString("id_devices"),
                            FirstName = reader.GetString("firstname"),
                            LastName = reader.GetString("lastname"),
                            Username = reader.GetString("username"),
                            UserID = reader.GetInt32("id_specs"),
                            Password = reader.GetString("password"),
                            Color = reader.GetString("color")

                        });
                    }
                }
                conn.Close();
            }
            return list;
        }

        public bool UpdateUser(User user, string requestedField, string requestedValue)
        {
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE user_data SET " + requestedField + "='" + requestedValue + "' WHERE id_alexa='" + user.AlexaID + "'", conn);
                cmd.ExecuteReader();
                conn.Close();
            }
            return true;
        }
    }
}
