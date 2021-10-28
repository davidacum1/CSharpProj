using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProj.Data.Model
{
        public class Sales
    {
        
        public int SaleID { get; set; }
       
        
        public string ProductName { get; set; }
        
        
        public int Quantity { get; set; }
       
        
        public decimal Price { get; set; }
       
        
        public DateTime SaleDate { get; set; }

        
        
        public override string ToString()
        {
            return $"Sales info: Sale ID: {SaleID}, ProductID: {ProductName}, Quantity: {Quantity}, Product Cost: {Price}, Sale Date: {SaleDate}";
        }


    }
}
