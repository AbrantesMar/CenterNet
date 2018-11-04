using CenterEntities;
using CenterIService;
using System;
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
                    PLevel = 1,
                    BirthYear = 1979,
                    AdmissionYear = 2011,
                    LastProgressionYear = 2013
                },
                new Employee
                {
                    Id = 4,
                    Description = "Luiz",
                    PLevel = 4,
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
            MergeRevert(company.Clientes);
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
                    Console.WriteLine("  - " + time.Description + " - Level: " + time.PLevel);
                }
            }
            Console.ReadLine();
        }
        public void Telas()
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------");
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

        public static void MergeRevert(List<Client> clients)
        {
            Client seniorClient = new Client();
            Client jrClient = new Client();
            Employee jrEmp = new Employee();
            Employee seniorEmp = new Employee();
            clients.Sort((x, y) => x.EmployeesCount.CompareTo(y.EmployeesCount));

            for (int i = 0, count = clients.Count, backCount = clients.Count - 1; i < clients.Count; i++)
            {
                Client client = clients[i];
                if (i != backCount)
                {
                    Client clientNext = clients[i + 1];
                    if (client.EmployeesCount < 0)
                    {
                        if (client.MinMaturity > clientNext.MinMaturity)
                        {
                            client.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
                            seniorEmp = clientNext.Time[0];
                            jrEmp = client.Time[client.Time.Count - 1];

                            client.Time.Remove(jrEmp);
                            clientNext.Time.Remove(seniorEmp);
                            client.Time.Add(seniorEmp);
                            clientNext.Time.Add(jrEmp);
                        }
                        else
                        {
                            client.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
                            clientNext.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
                            //seniorEmp = client.Time[0];
                            jrEmp = client.Time[client.Time.Count - 1];

                            //client.Time.Remove(jrEmp);
                            client.Time.Remove(jrEmp);
                            clientNext.Time.Add(jrEmp);
                        }
                    }
                    else
                    {
                        if(i > 0)
                        {
                            Client clientBack = clients[i - 1];
                            if(client.MinMaturity > clientBack.MinMaturity && client.EmployeesCount < clientBack.MinMaturity)
                            {
                                clientBack.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
                                //seniorEmp = clientNext.Time[0];
                                jrEmp = clientBack.Time[0];

                                // client.Time.Remove(jrEmp);
                                clientBack.Time.Remove(seniorEmp);
                                client.Time.Add(seniorEmp);
                                //clientNext.Time.Add(jrEmp);
                            }
                        }
                    }
                    clients[i] = client;
                    clients[i + 1] = clientNext;
                }
                else
                {
                    Client clientNext = clients[i - 1];
                    if (client.EmployeesCount < 0)
                    {
                        if (client.MinMaturity > clientNext.MinMaturity)
                        {
                            client.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
                            clientNext.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
                            //seniorEmp = client.Time[0];
                            jrEmp = client.Time[0];

                            //client.Time.Remove(jrEmp);
                            client.Time.Remove(jrEmp);
                            clientNext.Time.Add(jrEmp);
                            //clientNext.Time.Add(jrEmp);
                        }
                    }
                    else
                    {
                        client.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
                        clientNext.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
                        //seniorEmp = client.Time[0];
                        jrEmp = clientNext.Time[clientNext.Time.Count - 1];

                        //client.Time.Remove(jrEmp);
                        clientNext.Time.Remove(jrEmp);
                        client.Time.Add(jrEmp);
                        //clientNext.Time.Add(jrEmp);
                    }
                    clients[i] = client;
                    clients[i - 1] = clientNext;
                }
            }

            clients.Sort((x, y) => x.MinMaturity.CompareTo(y.MinMaturity));
            for (int i = 0; i < clients.Count; i++)
            {
                if ((i > 0) && (i <= (clients.Count - 2)))
                {
                    if (clients[i].MinMaturity > clients[i + 1].MinMaturity && ((clients[i].EmployeesCount > clients[i + 1].EmployeesCount) || (clients[i].EmployeesCount > clients[i - 1].EmployeesCount))) MergeRevert(clients);
                    else if (!(clients[i].MinMaturity > clients[i + 1].MinMaturity) && ((clients[i].EmployeesCount < clients[i + 1].EmployeesCount)))
                    {
                        MergeRevert(clients);
                    }
                }
                else if(i == 0)
                {
                    if (!(clients[i].MinMaturity > clients[i + 1].MinMaturity) && ((clients[i].EmployeesCount > clients[i + 1].EmployeesCount)))
                    {
                        MergeRevert(clients);
                    }
                }

            }
        }
        
    }
}
