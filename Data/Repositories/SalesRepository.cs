using CSharpProj.Data.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpProj.Data.Repositories;


namespace CSharpProj.Data.Repositories
{
    class SalesRepository
    {
        private readonly MySqlConnection connection;

        public SalesRepository(MySqlConnection mySqlConnection)
        {
            connection = mySqlConnection;
        }



       
        
        
        internal Sales Create(Sales toCreate)
        {

            MySqlCommand command = connection.CreateCommand();
            
            command.CommandText = "INSERT INTO sales(prodName, quantity, price, saleDate) VALUES(@Name, @Quantity, @Price, @SaleDate)";
            
            command.Parameters.AddWithValue("@Name", toCreate.ProductName);
            
            command.Parameters.AddWithValue("@Quantity", toCreate.Quantity);
            
            command.Parameters.AddWithValue("@Price", toCreate.Price);
            
            command.Parameters.AddWithValue("@SaleDate", toCreate.SaleDate);

            

            connection.Open();
            command.Prepare();
            
            command.ExecuteNonQuery();


            Sales sale = new Sales();
            sale.SaleID = (int)command.LastInsertedId;
            
            sale.ProductName = toCreate.ProductName;
            
            sale.Quantity = toCreate.Quantity;
            
            sale.Price = toCreate.Price;
            
            sale.SaleDate = toCreate.SaleDate;

            connection.Dispose();

            return sale;
        }



       
        
        
        
        
        internal IEnumerable<Sales> ReadByYear(int year)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM sales WHERE YEAR(saleDate) = @saleYear";
            
            command.Parameters.AddWithValue("@saleYear", year);

            connection.Open();
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();

            IList<Sales> sales = new List<Sales>();

            while (reader.Read())
            {
                int id = reader.GetFieldValue<int>("saleID");
                
                string name = reader.GetFieldValue<string>("prodName");
                
                int quantity = reader.GetFieldValue<int>("quantity");
                
                decimal price = reader.GetFieldValue<decimal>("price");
                
                DateTime saleID = reader.GetFieldValue<DateTime>("saleDate");

                Sales sale = new Sales() { SaleID = id, ProductName = name, Quantity = quantity, Price = price, SaleDate = saleID };
                sales.Add(sale);

            }

            connection.Dispose();
            return sales;


        }

       
        
        
        
        
        internal IEnumerable<Sales> ReadByMonth(int year, int month)
        {
            MySqlCommand command = connection.CreateCommand();
            
            command.CommandText = "SELECT * FROM sales WHERE YEAR(DATE(saleDate)) = @saleYear AND MONTH(DATE(saleDate))= @saleMonth";
            
            command.Parameters.AddWithValue("@saleYear", year);
            
            command.Parameters.AddWithValue("@saleMonth", month);

            connection.Open();
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();

            IList<Sales> sales = new List<Sales>();

            while (reader.Read())
            {
                int id = reader.GetFieldValue<int>("saleID");
                
                string name = reader.GetFieldValue<string>("prodName");
                
                int quantity = reader.GetFieldValue<int>("quantity");
                
                decimal price = reader.GetFieldValue<decimal>("price");
                
                DateTime saleID = reader.GetFieldValue<DateTime>("saleDate");

                Sales sale = new Sales() { SaleID = id, ProductName = name, Quantity = quantity, Price = price, SaleDate = saleID };
                sales.Add(sale);

            }

            connection.Dispose();
            return sales;


        }

       
        
        
        
        
        internal double TotalSalesYear(int totalSalesYear)
        {


            MySqlCommand command = connection.CreateCommand();
            
            command.CommandText = "SELECT SUM(quantity*price) FROM sales WHERE YEAR(DATE(saleDate)) = @saleYear";
            
            command.Parameters.AddWithValue("@saleYear", totalSalesYear);


            connection.Open();
            command.Prepare();
            var total = command.ExecuteScalar();
            double totalYear = Convert.ToDouble(total);



            connection.Dispose();
            return totalYear;


        }

       
        
        
        
        internal double TotalSalesMonth(int year, int month)
        {


            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT SUM(quantity*price) FROM sales WHERE YEAR(DATE(saleDate)) = @saleYear AND MONTH(DATE(saleDate))= @saleMonth";
            
            command.Parameters.AddWithValue("@saleYear", year);
            
            command.Parameters.AddWithValue("@saleMonth", month);

            connection.Open();
            command.Prepare();
            var total = command.ExecuteScalar();
            double totalMonth = Convert.ToDouble(total);



            connection.Dispose();
            return totalMonth;


        }

       
        
        
        
        
        internal IEnumerable<Sales> SalesBetweenYears(int year1, int year2)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM sales WHERE YEAR(DATE(saleDate)) >= @year1 AND YEAR(DATE(saleDate)) <= @year2";
            
            command.Parameters.AddWithValue("@year1", year1);
            
            command.Parameters.AddWithValue("@year2", year2);

            connection.Open();
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();

            IList<Sales> sales = new List<Sales>();

            while (reader.Read())
            {
                int id = reader.GetFieldValue<int>("saleID");
                
                string name = reader.GetFieldValue<string>("prodName");
                
                int quantity = reader.GetFieldValue<int>("quantity");
                
                decimal price = reader.GetFieldValue<decimal>("price");
                
                DateTime saleID = reader.GetFieldValue<DateTime>("saleDate");

                Sales sale = new Sales() { SaleID = id, ProductName = name, Quantity = quantity, Price = price, SaleDate = saleID };
                sales.Add(sale);

            }

            connection.Dispose();
            return sales;


        }

     



        internal double AverageGivenMonth(int month, int yearsPrev)
        {


            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT AVG(quantity* price) FROM sales WHERE YEAR(DATE(saleDate)) >= YEAR(CURDATE()) - @years AND MONTH(saleDate)=@month";
            
            command.Parameters.AddWithValue("@years", yearsPrev);
            
            command.Parameters.AddWithValue("@month", month);

            connection.Open();
            command.Prepare();
            var avg = command.ExecuteScalar();
            connection.Dispose();

            if (avg is DBNull)
            {
                double avgMonth = 0.0;
                
                return avgMonth;
            }
            else
            {
                double avgMonth = Convert.ToDouble(avg);
                
                return avgMonth;
            }




        }

        
    }
}
