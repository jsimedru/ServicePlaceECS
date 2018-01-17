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
    /// Model for proper(?) DB re-implementation
    /// </summary>
    public class User
    {

        [JsonIgnore]
        public AppDb Db { get; set; }
        //private UserContext context;

        public int UserID { get; set; }

        public string AlexaID { get; set; }

        public string Username { get; set; }

        //BAD -- FIX
        public string Password { get; set; }

        public string Color { get; set; }

        public string DeviceIDs { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public User(AppDb db = null) => Db = db;

        public async Task InsertAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO 'user_data' ('AlexaId', 'Username', 'Password', 'Color', 'DeviceIDs', 'FirstName', 'LastName') VALUES (@id_alexa, @username, @password, @color, @id_devices, @firstname, @lastname);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            UserID = (int) cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE 'user_data' SET 'AlexaId' = @id_alexa, 'Username' = @username, 'Password' = @password, 'Color' = @color, 'DeviceIDs' = @id_devices, 'FirstName' = @firstname, 'LastName' = @lastname;";
            BindParams(cmd);
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id_alexa",
                DbType = System.Data.DbType.String,
                Value = AlexaID,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@username",
                DbType = System.Data.DbType.String,
                Value = Username,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@password",
                DbType = System.Data.DbType.String,
                Value = Password,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@color",
                DbType = System.Data.DbType.String,
                Value = AlexaID,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id_devices",
                DbType = System.Data.DbType.String,
                Value = DeviceIDs,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@firstname",
                DbType = System.Data.DbType.String,
                Value = FirstName,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@lastname",
                DbType = System.Data.DbType.String,
                Value = LastName,
            });
        }
    }
}
