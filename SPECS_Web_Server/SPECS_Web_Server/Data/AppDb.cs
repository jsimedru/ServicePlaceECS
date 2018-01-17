using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SPECS_Web_Server.Data
{
    public class AppDb : IDisposable
    {
        public readonly MySqlConnection Connection;

        public AppDb()
        {
            Connection = new MySqlConnection("server=localhost;port=3306;user id=root;password=root;database=specs;");
        }

        public AppDb(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
