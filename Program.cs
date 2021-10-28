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

            MySqlUtils.RunSchema(Environment.CurrentDirectory + @"\Resources\Schema.sql", connection);

            connection.Close();
        }
    }
}
