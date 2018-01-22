using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SPECS_Web_Server.Models;
namespace SPECS_Web_Server.Data
{
    public class UserQuery
    {
        public readonly AppDb Db;
        public UserQuery(AppDb db) => Db = db;

        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM user_data", Db.Connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new User()
                    {
                        ID = reader.GetInt32("id"),
                        AlexaID = reader.GetString("id_alexa"),
                        Color = reader.GetString("color"),
                        DeviceIDs = reader.GetString("id_devices"),
                        FirstName = reader.GetString("firstname"),
                        LastName = reader.GetString("lastname"),
                        Password = reader.GetString("password"),
                        Email = reader.GetString("email")
                    });
                }

            }
            return list;
        }

        public User FindAlexaUser(string alexaID)
        {
            User user;
            string cmdString = "SELECT * FROM user_data WHERE id_alexa='" + alexaID + "';";
            MySqlCommand cmd = new MySqlCommand(cmdString, Db.Connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    user = new User()
                    {
                        ID = reader.GetInt32("id"),
                        AlexaID = reader.GetString("id_alexa"),
                        Color = reader.GetString("color"),
                        DeviceIDs = reader.GetString("id_devices"),
                        FirstName = reader.GetString("firstname"),
                        LastName = reader.GetString("lastname"),
                        Username = reader.GetString("username"),
                        Email = reader.GetString("email")
                    };
                    return user;
                }
            }
            return null;
        }

        public bool UpdateUserColorByAlexaID(User user, string color)
        {
            if (user == null || color == null)
            {
                return false;
            }
            try
            {
                string cmdString = "UPDATE user_data SET color='" + color + "' WHERE 'id'='" + user.ID + "';";
                MySqlCommand cmd = new MySqlCommand(cmdString, Db.Connection);
                cmd.ExecuteNonQuery();
                return true;
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
