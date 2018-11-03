using CenterEntities;
using CenterIService;
using System.Collections.Generic;

namespace CenterApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeers = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Description = "Diego",
                    PLevel = 3,
                    BirthYear = 1991,
                    AdmissionYear = 2011,
                    LastProgressionYear = 2015
                },
                new Employee
                {
                    Id = 2,
                    Description = "Lucas",
                    PLevel = 4,
                    BirthYear = 1990,
                    AdmissionYear = 2012,
                    LastProgressionYear = 2017
                },
                new Employee
                {
                    Id = 3,
                    Description = "Luciano",
                    PLevel = 2,
                    BirthYear = 1979,
                    AdmissionYear = 2011,
                    LastProgressionYear = 2013
                },
                new Employee
                {
                    Id = 4,
                    Description = "Luiz",
                    PLevel = 5,
                    BirthYear = 1980,
                    AdmissionYear = 2005,
                    LastProgressionYear = 2014
                },
                new Employee
                {
                    Id = 5,
                    Description = "Daniel",
                    PLevel = 2,
                    BirthYear = 1989,
                    AdmissionYear = 2013,
                    LastProgressionYear = 2015
                },
                new Employee
                {
                    Id = 6,
                    Description = "José Carlos",
                    PLevel = 2,
                    BirthYear = 1994,
                    AdmissionYear = 2013,
                    LastProgressionYear = 2016
                },
                new Employee
                {
                    Id = 7,
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

            FormulateTime(company.Clientes, employeers);

            foreach (var client in company.Clientes)
            {
                System.Text.StringBuilder strDescription = new System.Text.StringBuilder()
                                                                        .Append(client.Description)
                                                                        .Append("   -   LevelTime: ")
                                                                        .Append(client.MinMaturity)
                                                                        .Append(" --- Maturidade: ")
                                                                        .Append(client.MaxMaturity)
                                                                        .Append(" - ")
                                                                        .Append(client.EmployeesCount);
                System.Console.WriteLine(strDescription.ToString());
                foreach (var time in client.Time)
                {
                    System.Console.WriteLine("  - " + time.Description + " - Level: " + time.PLevel);
                }
            }
            System.Console.ReadLine();
        }

        private static void FormulateTime(List<Client> clientes, List<Employee> employeers)
        {
            List<Employee> employees = employeers;
            List<int> empId = new List<int>();
            for (int i = 0, clientCount = clientes.Count - 1; i <= clientCount; clientCount--)
            {
                Client client = clientes[clientCount];
                for (int j = 0; j < employees.Count; j++)
                {
                    Employee employee = employees[j];
                    if (empId.Contains(employee.Id))
                        continue;
                    if (client.Time.Count > 0)
                    {
                        if (ValidateMaturity(employee.PLevel, client.MinMaturity, client.EmployeesCount, clientCount))
                        {
                            TimeAdd(employee, employees, client.Time, empId);
                            j = j - 1;
                        }
                        else if (client.EmployeesCount <= 0)  break;
                    }
                    else if (employee.PLevel <= client.MinMaturity || (employee.PLevel >= client.MinMaturity && clientCount == 0))
                    {
                        TimeAdd(employee, employees, client.Time, empId);
                        j = j - 1;
                    }
                }
                clientes[clientCount] = client;
            }
        }

        public static void TimeAdd(Employee employee, List<Employee> employees, List<Employee> time, List<int> empId)
        {
            time.Add(employee);
            empId.Add(employee.Id);
            employees.Remove(employee);
        }

        public static bool ValidateMaturity(int level, int minMaturity, int employeesCount, int clientCount)
        {
            bool toBack = false;
            if(level == employeesCount)
            {
                toBack = true;
            }
            else if(level > employeesCount && clientCount == 0){
                toBack = true;
            }
            return toBack;
        }

        public static void MergeTime(List<Client> clients)
        {
            Client seniorClient = new Client();
            Client seniorForEmployee = new Client();
            Employee jrEmp = new Employee();
            Employee seniorEmp = new Employee();

            clients.Sort((x, y) => x.MaxMaturity.CompareTo(y.MaxMaturity));
            seniorForEmployee = clients[0];

            clients[0].Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
            jrEmp = clients[0].Time[0];

            clients.Sort((x, y) => x.MinMaturity.CompareTo(y.MinMaturity));
            seniorClient = clients[clients.Count - 1];
            
        }
        
    }
}
