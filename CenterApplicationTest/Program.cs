using CenterEntities;
using CenterIService;
using System.Collections.Generic;

namespace CenterApplicationTest
{
    class Program
    {
        //private static IEmployeeService _employeeService;
        static void Main(string[] args)
        {
            List<Employee> employeers = new List<Employee>()
            {
                new Employee
                {
                    Description = "Diego",
                    PLevel = 3,
                    BirthYear = 1991,
                    AdmissionYear = 2011,
                    LastProgressionYear = 2015
                },
                new Employee
                {
                    Description = "Lucas",
                    PLevel = 4,
                    BirthYear = 1990,
                    AdmissionYear = 2012,
                    LastProgressionYear = 2017
                },
                new Employee
                {
                    Description = "Luciano",
                    PLevel = 1,
                    BirthYear = 1979,
                    AdmissionYear = 2011,
                    LastProgressionYear = 2013
                },
                new Employee
                {
                    Description = "Luiz",
                    PLevel = 4,
                    BirthYear = 1980,
                    AdmissionYear = 2005,
                    LastProgressionYear = 2014
                },
                new Employee
                {
                    Description = "Daniel",
                    PLevel = 2,
                    BirthYear = 1989,
                    AdmissionYear = 2013,
                    LastProgressionYear = 2015
                },
                new Employee
                {
                    Description = "José Carlos",
                    PLevel = 2,
                    BirthYear = 1994,
                    AdmissionYear = 2013,
                    LastProgressionYear = 2016
                },
                new Employee
                {
                    Description = "Felipe",
                    PLevel = 3,
                    BirthYear = 1976,
                    AdmissionYear = 2018,
                    LastProgressionYear = 2018
                }

            };

            Company company = new Company
            {
                Id = 0,
                Description = "Cliente 1",
                FiscalYear = 2019,
                Clientes = new List<Client>()
                    {
                        new Client
                        {
                            Id = 1,
                            Description = "Cliente 1",
                            Time = new List<Employee>(),
                            MinMaturity = 3
                        },
                        new Client
                        {
                            Id = 2,
                            Description = "Cliente 2",
                            Time = new List<Employee>(),
                            MinMaturity = 5
                        },
                        new Client
                        {
                            Id = 3,
                            Description = "Cliente 3",
                            Time = new List<Employee>(),
                            MinMaturity = 7
                        }
                    }
            };
            List<Client> clientes = company.Clientes;
            for (int i = 0, clientCount = clientes.Count - 1; i <= clientCount; clientCount--)
            {
                Client client = clientes[clientCount];
                for (int j = 0; j < employeers.Count; j++)
                {
                    if (client.Time.Count > 0)
                    {
                        if (Validate(employeers[j].PLevel, client.MinMaturity, client.EmployeesCount, clientCount, (i + 1)))
                        {
                            client.Time.Add(employeers[j]);
                            employeers.Remove(employeers[j]);
                        }
                    }
                    else if(employeers[j].PLevel <= client.MinMaturity)
                    {
                        client.Time.Add(employeers[j]);
                        employeers.Remove(employeers[j]);
                    }
                }
                clientes[clientCount] = client;
            }
            company.Clientes = clientes;
            System.Console.ReadLine();
        }

        public static bool Validate(int level, int minMaturity, int employeesCount, int clientCount, int position)
        {
            return ((level <= (minMaturity - employeesCount)) || clientCount == (position + 1));
        }
        
    }
}
