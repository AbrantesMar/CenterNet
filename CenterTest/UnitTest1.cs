/*using System.Collections.Generic;
using CenterEntities;
using CenterIService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CenterTest
{
    [TestClass]
    public class UnitTest1
    {
        //private static IEmployeeService _employeeService;
        private static IClientService _clientService;
        public List<Employee> employeer;

        [TestMethod]
        public void TestMethod1()
        {
            employeer = _employeeService.BubbleSort(new List<Employee>()
            {
                new Employee
                {
                    AdmissionYear = 2011,
                    BirthYear = 1991,
                    Description = "Diego",
                    Id = 0,
                    LastProgressionYear = 2015,
                    PLevel = 3
                },
                new Employee
                {
                    AdmissionYear = 2012,
                    BirthYear = 1990,
                    Description = "Lucas",
                    Id = 1,
                    LastProgressionYear = 2017,
                    PLevel = 4
                },
                new Employee
                {
                    AdmissionYear = 2011,
                    BirthYear = 1979,
                    Description = "Luciano",
                    Id = 2,
                    LastProgressionYear = 2013,
                    PLevel = 1
                },
                new Employee
                {
                    AdmissionYear = 2005,
                    BirthYear = 1980,
                    Description = "Luiz",
                    Id = 3,
                    LastProgressionYear = 2014,
                    PLevel = 4
                },
                new Employee
                {
                    AdmissionYear = 2013,
                    BirthYear = 1989,
                    Description = "Daniel",
                    Id = 4,
                    LastProgressionYear = 2015,
                    PLevel = 2
                },
                new Employee
                {
                    AdmissionYear = 2005,
                    BirthYear = 1980,
                    Description = "José Carlos",
                    Id = 5,
                    LastProgressionYear = 2016,
                    PLevel = 2
                },
                new Employee
                {
                    AdmissionYear = 2018,
                    BirthYear = 1994,
                    Description = "Felipe",
                    Id = 3,
                    LastProgressionYear = 2018,
                    PLevel = 3
                }
            });
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
            //Cliente 1,3
            //Cliente 2,5
            //Cliente 3,7
            companies[0].Clientes.Add(new Client
            {
                Id = 0,
                Description = "Client 1",
                MinMaturity = 3
            });
            companies[1].Clientes.Add(new Client
            {
                Id = 1,
                Description = "Client 2",
                MinMaturity = 5
            });
            companies[2].Clientes.Add(
            new Client
            {
                Id = 2,
                Description = "Client 3",
                MinMaturity = 7
            });
        }
    }
}*/
