using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SPECS_Web_Server.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
namespace SPECS_Web_Server.Data
{
    public class UserQuery
    {
        public readonly AppDb Db;
        public UserQuery(AppDb db) => Db = db;

        /// <summary>
        /// Retrieve all users
        /// </summary>
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
                        FirstName = reader.GetString("firstname"),
                        LastName = reader.GetString("lastname"),
                        Username = reader.GetString("username"),
                        Password = reader.GetString("password"),
                        Phone = reader.GetInt32("phone"),
                        Email = reader.GetString("email"),
                        Address = reader.GetString("address")
                    });
                }

            }
            return list;
        }

        /// <summary>
        /// Registers a user, TODO: Test implementation, do we need to open & close connection here??
        /// </summary>
        public async Task<bool> RegisterUserAsync(User user, String pwd)
            {
                if (user == null)
                {
                    return false;
                }
                try
                {   
                    //Insert User into user Table
                    string cmdString = "INSERT INTO user_data (username, firstname, lastname, email, phone, address) VALUES ('" + user.Username + "', '" + user.FirstName + "', '" + user.LastName + "', '" + user.Email + "', '" + user.Phone + "', '" + user.Address + "');";
                    MySqlCommand cmd = new MySqlCommand(cmdString, Db.Connection);
                    await cmd.ExecuteNonQueryAsync();
                    long insertedUserID = cmd.LastInsertedId;

                    //Insert salt & hash into auth table
                    var salthash = hashpwd(pwd);
                    cmdString = "INSERT INTO auth (userid, phash, psalt) VALUES ('" + insertedUserID + "', '" + salthash.hash + "', '" + salthash.salt + "');";
                    cmd = new MySqlCommand(cmdString, Db.Connection);
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                } catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }

        /// <summary>
        /// Gets a user given an Alexa user_id TODO: Re-Implement with proper db structure & queries
        /// </summary>        
        public User FindAlexaUser(string alexaID)
        {
            User user;
            //Re-implement using relational table to get user alexa_id
            string cmdString = "SELECT * FROM user_data WHERE id_alexa='" + alexaID + "';";
            MySqlCommand cmd = new MySqlCommand(cmdString, Db.Connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    user = new User()
                    {
                        ID = reader.GetInt32("id"),
                        /* Re-implement with correct DB Structure
                        AlexaID = reader.GetString("id_alexa"),
                        Color = reader.GetString("color"),
                        DeviceIDs = reader.GetString("id_devices"), */
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

    /// <summary>
    /// Test Method for POC, TODO: future removal
    /// </summary>
        public bool UpdateUserColorByAlexaID(User user, string color)
        {
            if (user == null || color == null)
            {
                return false;
            }
            try
            {
                //Re-implement using proper alexa skill tables & relational tables
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

        ///<summary>
        ///Hashes password returning (salt, saltedhash)
        ///</summary>
        private (byte[] salt, string hash) hashpwd(String pwd){
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create() ){
                rng.GetBytes(salt);
            }
            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pwd,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hash}");
            return (salt, hash);
        }
    }
}
