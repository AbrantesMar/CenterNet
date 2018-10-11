using CenterEntities;
using System.Collections.Generic;

namespace CenterApplicationTest
{
    class Program
    {
        private static CenterIService.IEmployeeService _employeeService;
        static void Main(string[] args)
        {
            List<Employee> employeer = _employeeService.BubbleSort(new List<Employee>());
            List<Company> companies = new List<Company>() { 
                new Company
                {
                    Id = 0,
                    Description = "Cliente 1",
                    FiscalYear = 3
                },
                new Company
                {
                    Id = 1,
                    Description = "Cliente 2",
                    FiscalYear = 5
                },
                new Company
                {
                    Id = 2,
                    Description = "Cliente 3",
                    FiscalYear = 7
                }
            };
        }
    }
}
