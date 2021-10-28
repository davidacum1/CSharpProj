using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpProj.Controllers;
using CSharpProj.Data.Repositories;
using CSharpProj.Services;
using CSharpProj.Utils;

namespace CSharpProj.Menus
{
    class SalesMenu
    {
        public static void EnterMenu()
        {
            Console.WriteLine("---MAIN MENU---");
           
            Console.Write("Please pick an option: \n 1. Data entry \n 2. Reports \n 3. Quit \n");
            
            Console.Write("> ");
            
            string input = Console.ReadLine();
           
            switch (input.ToUpper())
            {
                
                case "DATA ENTRY" or "DATAENTRY" or "1":
                   
                    DataEntryMenu();
                    break;
                
                
                case "REPORTS" or "2":
                    
                    ReportsMenu();
                    break;
               
                
                case "QUIT" or "3":
                    break;
               
                
                default:
                   
                    Console.WriteLine("Please enter a valid option. For example, for data entry enter 1.  Press any key to continue..");
                   
                    Console.ReadKey();
                    
                    Console.Clear();
                   
                    EnterMenu();
                    break;


            }
        }

       
        
        
        
        public static void DataEntryMenu()
        {
            SalesController controller = new SalesController(new SalesService(new SalesRepository(MySqlUtils.GetConnection())));
            
            
            bool inMenu = true;
            
            string input;

            while (inMenu)
            {
                
                Console.Clear();
                
                
                Console.WriteLine("---DATA ENTRY---");
                
                
                Console.WriteLine("1. Enter Data \n 2. Back to main menu \n 3. Quit"); //add back to main menu

                input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "ENTERDATA" or "ENTER DATA" or "1":
                        controller.Create();
                        break;
                    
                    
                    case "MAINMENU" or "MAIN MENU" or "2":
                        Console.Clear();
                        inMenu = false;
                        EnterMenu();
                        break;

                    
                    
                    case "QUIT" or "3":
                        inMenu = false;
                        break;
                    
                    
                    default:
                        Console.WriteLine("Please enter a valid option. For example, to enter data, press 1.  Press any key to continue");
                        
                        Console.ReadKey();
                        
                        Console.Clear();
                        break;



                }






            }


        }

        
        
        
        public static void ReportsMenu()
        {
            SalesController controller = new SalesController(new SalesService(new SalesRepository(MySqlUtils.GetConnection())));
            
            bool inMenu = true;
            
            string input;

            while (inMenu)
            {
                
                Console.Clear();
                
                Console.WriteLine("---REPORTS---");
                
                Console.WriteLine("1. View sales by year \n 2. View sales by month and year \n 3. View total sales by year \n 4. View total sales by year and month \n 5. View all sales between two specified years \n 6. View the average sales for a given month \n 7. Back to main menu \n 8. Quit");

               
                
                Console.WriteLine();
                
                Console.WriteLine("Please enter your choice (enter the option number e.g. 1 to view sales by year):");
               
                Console.Write("> ");
                
                input = Console.ReadLine();
                
                switch (input.ToUpper())
                {
                    //ADD MORE CASE WORDING
                    case "YEAR" or "1":
                        controller.ReadByYear();
                        break;
                    
                    
                    case "2":
                        controller.ReadByMonth();
                        break;
                    
                    
                    case "3":
                        controller.TotalSalesYear();
                        break;
                   
                    
                    case "4":
                        controller.TotalSalesMonth();
                        break;
                   
                    
                    case "5":
                        controller.SalesBetweenYears();
                        break;
                    
                    
                    case "6":
                        controller.AverageGivenMonth();
                        break;
                    
                    
                    case "7":
                        Console.Clear();
                        inMenu = false;
                        EnterMenu();
                        break;
                    
                    
                    case "QUIT" or "8":
                        inMenu = false;
                        break;
                    
                    
                    default:
                       
                        Console.WriteLine("Please enter a valid option. For example, to view sales by year, enter 1.  Press any key to continue..");
                        
                        Console.ReadKey();
                        
                        Console.Clear();
                        break;




                }
            }
        }
    }
}
