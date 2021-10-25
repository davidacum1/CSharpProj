using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProj
{
    class SQLUtils
    {
        public static MySqlConnectionStringBuilder ConnectionString { get; set; } = new MySqlConnectionStringBuilder
        {
            Server = "127.0.0.1",
            UserID = "root",
            Password = "root",
            Port = 3306,
            Database = "SalesDatabase",
            AllowBatch = true,
            AllowLoadLocalInFileInPath = "./",
            AllowLoadLocalInFile = false,
            ConnectionTimeout = 30

        };

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString.ConnectionString);
        }

        public static void RunSchema(string path, MySqlConnection connection)
        {
            string schema = File.ReadAllText(path);
            MySqlCommand mySqlCommand = connection.CreateCommand();
            mySqlCommand.CommandText = schema;

            mySqlCommand.ExecuteNonQuery();
        }

    }
}
