using CenterEntities;
using CenterIService;
using CentralServices;
using System;
using System.Collections.Generic;

namespace CenterApplicationTest
{
    class Program
    {

        public static ClientService clientService = new ClientService();
        public static EmployeeService employeeService = new EmployeeService();

        static void Main(string[] args)
        {
            
            List<Employee> employeers = employeeService.GetEmployees();

            Company company = new Company
            {
                Id = 0,
                Description = "Cliente 1",
                FiscalYear = 2019
            };
            company.Clientes = clientService.GetClientByFile();
            Tela(company, employeers);
            
            Console.ReadLine();
        }
        public static void Tela(Company company, List<Employee> employees)
        {
            Console.WriteLine(".------------------------------------------------------------------------------.");
            Console.WriteLine("|---  ClientTime                                                               |");
            Console.WriteLine("|Opções:                                                                       |");
            Console.WriteLine("|-   2- Promover                                                               |");
            Console.WriteLine("|-   3- Recalibrar                                                             |");
            Console.WriteLine("|-   4- Montar time                                                            |");
            Console.WriteLine("|-   5- Visualizar Resultados                                                  |");
            Console.WriteLine("|-   6- limpar Tela                                                            |");
            Console.WriteLine("|-   Digite o que deseja.                                                      |");
            Console.WriteLine("'------------------------------------------------------------------------------'");
            switch (Console.ReadLine())
            {
                case "2":
                    Console.WriteLine(".---------------- Digite a quantidade a serem promovidos ----------------------.");
                    int quantityPromotions = 0;
                    quantityPromotions = Convert.ToInt32(Console.ReadLine());
                    employees = employeeService.Progression(employees, quantityPromotions);
                    clientService.FormulateTime(company.Clientes, employees);
                    clientService.MergeRevert(company.Clientes);
                    Console.Clear();
                    Console.WriteLine(".------------------------- Processado com sucesso -----------------------------.");
                    Console.WriteLine(".------------------------------------------------------------------------------.");
                    break;
                case "3":
                    clientService.MergeRevert(company.Clientes);
                    Console.Clear();
                    Console.WriteLine(".------------------------- Processado com sucesso -----------------------------.");
                    Console.WriteLine(".------------------------------------------------------------------------------.");
                    break;
                case "4":
                    clientService.FormulateTime(company.Clientes, employees);
                    Console.Clear();
                    Console.WriteLine(".------------------------- Processado com sucesso -----------------------------.");
                    Console.WriteLine(".------------------------------------------------------------------------------.");   
                    break;
                case "5":
                    Console.WriteLine(".------------------------- Click para sair da tela -----------------------------.");
                    WriteResult(company);
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(".------------------------- Processado com sucesso -----------------------------.");
                    Console.WriteLine(".------------------------------------------------------------------------------.");
                    break;
                case "6":
                    Console.Clear();
                    break;
                default:
                    break;
            }
            Tela(company, employees);
        }

        public static void WriteResult(Company company)
        {
            foreach (var client in company.Clientes)
            {
                System.Text.StringBuilder strDescription = new System.Text.StringBuilder()
                                                                        .Append(client.Description)
                                                                        .Append("   -   LevelTime: ")
                                                                        .Append(client.MinMaturity)
                                                                        .Append(" --- Maturidade: ")
                                                                        .Append(client.MaxMaturity);
                System.Console.WriteLine(strDescription.ToString());
                foreach (var time in client.Time)
                {
                    Console.WriteLine("  - " + time.Description + " - Level: " + time.PLevel);
                }
            }
        }
        
    }
}
