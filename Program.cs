using CSharpProj.Utils;
using MySql.Data.MySqlClient;
using System;

namespace CSharpProj
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connection = MySqlUtils.GetConnection();

            connection.Open();

            bool connectionOpen = connection.Ping();

            MySqlUtils.RunSchema(Environment.CurrentDirectory + @"\Resources\Schema.sql", connection);

            Console.WriteLine($@"\nConnection status: {connection.State}
Ping successful: {connectionOpen}  
DB Version: {connection.ServerVersion}
Connection String: {connection.ConnectionString}");

            connection.Dispose();
        }
    }
}
