using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
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
        /// Retrieve all users, TODO: Make ASYNC?
        /// </summary>
        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM user", Db.Connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                try
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            ID = reader.GetInt64("userid"),
                            FirstName = reader.GetString("firstname"),
                            LastName = reader.GetString("lastname"),
                            Username = reader.GetString("username"),
                            Phone = reader.GetInt32("phone"),
                            Email = reader.GetString("email"),
                            Address = reader.GetString("address1")
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }
            return list;
        }

        /// <summary>
        /// Retrieve a single user, TODO: Make ASYNC?
        /// </summary>
        public User GetUser(string email)
        {
            User user = new User();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE email='" + email + "';", Db.Connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                try{
                    while (reader.Read()) {
                        user.ID = reader.GetInt64("userid");
                        user.FirstName = reader.GetString("firstname");
                        user.LastName = reader.GetString("lastname");
                        user.Username = reader.GetString("username");
                        user.Phone = reader.GetInt64("phone");
                        user.Email = reader.GetString("email");
                        user.Address = reader.GetString("address1");
                    }
                } catch(Exception e){
                    Console.WriteLine(e.ToString());
                } 
                
            }
            return user;
        }

        /// <summary>
        /// Registers a user, TODO: CHECK FOR EXISTING USER, Test implementation, do we need to open & close connection here??
        /// </summary>
        public async Task<bool> RegisterUserAsync(User user, String pwd)
            {
                try
                {   
                    //Insert User into user Table
                    string cmdString = "INSERT INTO user (username, firstname, lastname, email, phone, address1) VALUES ('" + user.Username + "', '" + user.FirstName + "', '" + user.LastName + "', '" + user.Email + "', '" + user.Phone + "', '" + user.Address + "');";
                    MySqlCommand cmd = new MySqlCommand(cmdString, Db.Connection);
                    await cmd.ExecuteNonQueryAsync();
                    long insertedUserID = cmd.LastInsertedId;

                    //Store Password
                    await insertUserPassword(insertedUserID, pwd);
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
            string cmdString = "SELECT user.* FROM user INNER JOIN auth WHERE auth.userid = user.userid AND alexaid='" + alexaID + "';";
            MySqlCommand cmd = new MySqlCommand(cmdString, Db.Connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    user = new User()
                    {
                        ID = reader.GetInt64("userid"),
                        FirstName = reader.GetString("firstname"),
                        LastName = reader.GetString("lastname"),
                        Username = reader.GetString("username"),
                        Email = reader.GetString("email"),
                        Phone = reader.GetInt64("phone")
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
                string cmdString = "UPDATE user SET color='" + color + "' WHERE 'id'='" + user.ID + "';";
                MySqlCommand cmd = new MySqlCommand(cmdString, Db.Connection);
                cmd.ExecuteNonQuery();
                return true;
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        private async Task<int> insertUserPassword(long userid, string pwd){
            try{
                //Insert salt & hash into auth table
                var salthash = hashpwd(pwd);
                string cmdString = "INSERT INTO auth (userid, phash, psalt) VALUES ('" + userid + "', '" + salthash.hash + "', '" + Convert.ToBase64String(salthash.salt) + "');";
                MySqlCommand cmd = new MySqlCommand(cmdString, Db.Connection);
                return await cmd.ExecuteNonQueryAsync();
            } catch (Exception e){
                Console.WriteLine(e.ToString());
                return -1;
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

        ///<summary>
        ///Hashes password with a given salt
        ///</summary>
        private string hashpwd(String pwd, byte[] salt){
            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pwd,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hash;
        }

        ///<summary>
        ///Verify existing user's password, TODO: Implement
        ///</summary>
        public bool verifyUserPassword(string pwd, User user) => throw new NotImplementedException();

        ///<summary>
        ///Verify existing user's password, TODO: Implement
        ///</summary>
        public bool verifyUserPassword(string pwd, string userID) {
            string cmdString = "SELECT * FROM auth WHERE userid='" + userID + "';";
            MySqlCommand cmd = new MySqlCommand(cmdString, Db.Connection);

            bool pwdMatch = false;
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                        string pwdhash = reader.GetString("phash");
                        string pwdsaltString = reader.GetString("psalt");

                        byte[] pwdsalt = Encoding.ASCII.GetBytes(pwdsaltString);

                        var pwdEntered = hashpwd(pwd, pwdsalt);
                        if(pwdEntered == pwdhash){
                            pwdMatch = true;
                        }
                }
            }
            return pwdMatch;
        }

        ///<summary>
        ///Save a user's medical data
        ///</summary>
        public async Task<bool> saveMedicalDataAsync(MedicalSensorData data){
            if(data.userID == 0){
                return false;
            }
             try
                {   
                    //Insert Medical Data into skill_health Table
                    string cmdString = "INSERT INTO skill_health (bp, ecg, spo2, pulse, userid) VALUES ('" + data.BloodPressure + "', '" + data.ECG + "', '" + data.SpO2 + "', '" + data.Pulse + "," + data.userID + "');";
                    MySqlCommand cmd = new MySqlCommand(cmdString, Db.Connection);
                    await cmd.ExecuteNonQueryAsync();
                    long insertedUserID = cmd.LastInsertedId;

                    return true;
                } catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
        }

        ///<summary>
        ///Get a list of user's medical data
        ///</summary>
        public List<MedicalSensorData> GetUserMedicalData(int userID)
        {
            List<MedicalSensorData> list = new List<MedicalSensorData>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM skill_health WHERE userid = " + userID + ";", Db.Connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                try
                {
                    while (reader.Read())
                    {
                        list.Add(new MedicalSensorData()
                        {
                            userID = reader.GetInt64("userid"),
                            BloodPressure = reader.GetString("bp"),
                            ECG = reader.GetFloat("ecg"),
                            SpO2 = reader.GetFloat("spo2"),
                            Pulse = reader.GetInt32("pulse")

                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            return list;
        }
    }
}
