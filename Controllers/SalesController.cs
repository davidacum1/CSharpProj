using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpProj.Data.Model;
using CSharpProj.Services;
using CSharpProj.Data.Repositories;

namespace CSharpProj.Controllers
{
    class SalesController
    {


        private readonly SalesService salesService;

        public SalesController(SalesService salesService)
        {
            this.salesService = salesService;
        }



        
        
        
        internal void Create()
        {

            try
            {
                Console.Clear();
                
                Console.WriteLine("DATA ENTRY SELECTED");
               
                Console.WriteLine("What is the product name?");
               
                Console.Write("> ");
                
                
                string name = Console.ReadLine();
                Console.WriteLine("What is the quantity of the item?");
                
                Console.Write("> ");
                
                
                int quantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What is the price of the product?");
               
                Console.Write("> ");
                
                
                decimal price = Convert.ToDecimal(Console.Read());
                DateTime saleDate = DateTime.Now;


                Sales toCreate = new Sales() { ProductName = name, Quantity = quantity, Price = price, SaleDate = saleDate };

                Sales newSale = salesService.Create(toCreate);
                
                Console.WriteLine($"Sale entered: {newSale} ");
                
                Console.WriteLine("Press any key to continue");
                
                Console.ReadKey();
            }
            catch (FormatException e)
            {

                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();

            }


        }

       
        
        
        internal void ReadByYear()
        {
            try
            {
                Console.WriteLine("Please enter the year you wish to view:");
                
                Console.Write("> ");
                
                int year = Convert.ToInt32(Console.ReadLine());
                
                bool selectedYear = Convert.ToBoolean(year);
                IEnumerable<Sales> salesInDb = salesService.ReadByYear(year);
                if (selectedYear) 
                {

                    foreach (var sale in salesInDb)
                    {
                        Console.WriteLine(sale);
                    }
                    Console.WriteLine("Press any key to continue . .");
                    
                    Console.ReadKey();
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();

            }



        }

      
        
        
        
        internal void ReadByMonth()
        {
            try
            {

                Console.WriteLine("Month to view (numeric, e.g. for January enter 1):");
                
                Console.Write("Month > ");
                
                int month = Convert.ToInt32(Console.ReadLine());
                
                bool selectedMonth = Convert.ToBoolean(month);

                Console.WriteLine("Year to view:");
                
                Console.Write("Year > ");
                
                int year = Convert.ToInt32(Console.ReadLine());
                
                bool selectedYear = Convert.ToBoolean(year);

                IEnumerable<Sales> salesInDb = salesService.ReadByMonth(year, month);
                if (selectedYear && selectedMonth)
                {

                    foreach (var sale in salesInDb)
                    {
                        Console.WriteLine(sale);
                    }
                    Console.WriteLine();
                    
                    Console.WriteLine("Press any key to continue . .");
                    
                    Console.ReadKey();
                }
            }
            catch (FormatException e)
            {

                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();

            }



        }

       
        
        
        
        internal void TotalSalesYear()
        {

            try
            {
                Console.WriteLine("Please enter the year you wish to view:");

                Console.Write("Year > ");
                
                int totalSalesYear = Convert.ToInt32(Console.ReadLine());

                bool selectedYear = Convert.ToBoolean(totalSalesYear);


                if (selectedYear)
                {

                    Console.WriteLine($"Total number of sales is during {totalSalesYear} is: {salesService.TotalSalesYear(totalSalesYear)}");

                }

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

                
                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();

            }


        }

        
        
        
        
        internal void TotalSalesMonth()
        {
            try
            {
                Console.WriteLine("Please enter the year you wish to view:");

                Console.Write("Year > ");
                int year = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the month you wish to view:");

                Console.Write(" Month > ");
                int month = Convert.ToInt32(Console.ReadLine());

                bool selectedYear = Convert.ToBoolean(year);
                
                bool selectedMonth = Convert.ToBoolean(month);


                if (selectedYear && selectedMonth)
                {

                    Console.WriteLine($"Total number of sales during {NumToMonth(month)} in {year} is: {salesService.TotalSalesMonth(year, month)}");
                }

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();


            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();

            }


        }

       
        
        
        
        internal void SalesBetweenYears()
        {
            try
            {
               
                Console.WriteLine("Initial year:");
               
                Console.Write("Initial Year > ");
                
                int year1 = Convert.ToInt32(Console.ReadLine());
                
                bool firstYear = Convert.ToBoolean(year1);

                Console.WriteLine("Final year:");
                
                Console.Write("Final Year > ");
                
                int year2 = Convert.ToInt32(Console.ReadLine());
                
                bool secondYear = Convert.ToBoolean(year2);

                IEnumerable<Sales> salesInDb = salesService.SalesBetweenYears(year1, year2);
                if (firstYear && secondYear) // &&msalesservice.Exists(selectedyear
                {

                    foreach (var sale in salesInDb)
                    {
                        Console.WriteLine(sale);
                    }
                    Console.WriteLine("Press any key to continue . .");
                    
                    Console.ReadKey();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();

            }



        }


       
        
        
        internal void AverageGivenMonth()
        {
            try
            {
                Console.WriteLine("Please enter the month you wish to view:");

                Console.Write(" Month > ");
                int month = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the past number of years you wish to view:");

                Console.Write(" > ");
                int yearsPrev = Convert.ToInt32(Console.ReadLine());

                bool selectedMonth = Convert.ToBoolean(month);
                
                bool previousYears = Convert.ToBoolean(yearsPrev);


                if (selectedMonth && previousYears)
                {

                    Console.WriteLine($"Average sales during {NumToMonth(month)} for the past {yearsPrev} years : {salesService.AverageGivenMonth(month, yearsPrev)}");
                }

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();


            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);

                Console.WriteLine("Press any key to continue . .");
                
                Console.ReadKey();

            }


        }

       
        
        internal static string NumToMonth(int numMonth)
        {
            string monthName;

            switch (numMonth)
            {

                case 1:
                    monthName = "January";
                    break;
                
                case 2:
                    monthName = "February";
                    break;
                
                case 3:
                    monthName = "March";
                    break;
                
                case 4:
                    monthName = "April";
                    break;
                
                case 5:
                    monthName = "May";
                    break;
                
                case 6:
                    monthName = "June";
                    break;
                
                case 7:
                    monthName = "July";
                    break;
                
                case 8:
                    monthName = "August";
                    break;
                
                case 9:
                    monthName = "September";
                    break;
                
                case 10:
                    monthName = "October";
                    break;
                
                case 11:
                    monthName = "November";
                    break;
                
                case 12:
                    monthName = "December";
                    break;
                
                default:
                    monthName = "numMonth not valid";
                    break;



            }
            return monthName;
        }

       
        
        internal static int MonthNameToNum(string monthName)
        {
            int num;

            switch (monthName.ToUpper())
            {

                case "JAN" or "JANUARY":
                    num = 1;
                    break;
                
                case "FEB" or "FEBRUARY":
                    num = 2;
                    break;
                
                case "MAR" or "MARCH":
                    num = 3;
                    break;
                
                case "APR" or "APRIL":
                    num = 4;
                    break;
                
                case "MAY":
                    num = 5;
                    break;
                
                case "JUNE":
                    num = 6;
                    break;
                
                case "JUL" or "JULY":
                    num = 7;
                    break;
                
                case "AUG" or "AUGUST":
                    num = 8;
                    break;
                
                case "SEPT" or "SEP" or "SEPTEMBER":
                    num = 9;
                    break;
                
                case "OCT" or "OCTOBER":
                    num = 10;
                    break;
                
                case "NOV" or "NOVEMBER":
                    num = 11;
                    break;
                
                case "DEC" or "DECEMBER":
                    num = 12;
                    break;
                
                default:
                    num = 0;
                    break;



            }
            return num;
        }
    }
}
