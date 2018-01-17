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

        public async Task<User> FindWithAlexaIDAsync(string id)
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT 'id_specs', 'id_alexa', 'username', 'password', 'color', 'id_devices', 'firstname', 'lastname' FROM 'user_data' WHERE 'id_alexa' = @id_alexa;";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id_alexa",
                DbType = DbType.String,
                Value = id
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<User>> ReadAllAsync(DbDataReader reader)
        {
            var users = new List<User>();
            using (reader)
            {
                while(await reader.ReadAsync())
                {
                    var user = new User(Db)
                    {
                        UserID = await reader.GetFieldValueAsync<int>(0),
                        AlexaID = await reader.GetFieldValueAsync<string>(1),
                        Username = await reader.GetFieldValueAsync<string>(3),
                        Password = await reader.GetFieldValueAsync<string>(4),
                        Color = await reader.GetFieldValueAsync<string>(5),
                        DeviceIDs = await reader.GetFieldValueAsync<string>(6),
                        FirstName = await reader.GetFieldValueAsync<string>(7),
                        LastName = await reader.GetFieldValueAsync<string>(8)
                    };
                    users.Add(user);
                }
            }
            return users;
        }
    }
}
