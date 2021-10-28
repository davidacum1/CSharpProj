using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpProj.Data.Model;
using CSharpProj.Data.Repositories;

namespace CSharpProj.Services
{
    class SalesService
    {
        private readonly SalesRepository salesRepository;


       
        
        public SalesService(SalesRepository salesRepository)
        {
            this.salesRepository = salesRepository;
        }


        
        
        internal Sales Create(Sales toCreate)
        {
            Sales newSale = salesRepository.Create(toCreate);
            return newSale;

        }


      
        
        
        internal IEnumerable<Sales> ReadByYear(int year)
        {

            return salesRepository.ReadByYear(year);
        }

       
        
        
        internal IEnumerable<Sales> ReadByMonth(int year, int month)
        {

            return salesRepository.ReadByMonth(year, month);
        }

       
        
        
        internal double TotalSalesYear(int totalSalesYear)
        {

            return salesRepository.TotalSalesYear(totalSalesYear);
        }

       
        
        
        internal double TotalSalesMonth(int year, int month)
        {

            return salesRepository.TotalSalesMonth(year, month);
        }

        
        
        
        internal IEnumerable<Sales> SalesBetweenYears(int year1, int year2)
        {

            return salesRepository.SalesBetweenYears(year1, year2);
        }

       

       
        
        
        internal double AverageGivenMonth(int month, int yearsPrev)
        {

            return salesRepository.AverageGivenMonth(month, yearsPrev);
        }

    }
}
