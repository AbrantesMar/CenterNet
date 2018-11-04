using CenterEntities;
using CenterIRepository;
using CenterIService;
using System;
using System.Collections.Generic;

namespace CentralServices
{   
    public class EmployeeService : Service<Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private Employee _employee;

        public EmployeeService(IEmployeeRepository employeeRepository, IBaseRepository<Employee> repository) : base(repository) => _employeeRepository = employeeRepository;
        
        public List<Employee> Progression(List<Employee> employees, int quantityProgresso)
        {
            List<Employee> employeesProgress = BubbleSort(employees);
            List<Employee> employeesProgressValids = new List<Employee>();
            if (employeesProgress.Count <= quantityProgresso)
            {
                for (int i = 0, count = quantityProgresso; i < count; i++)
                {
                    _employee = employeesProgress[i];
                    if (GetIsTimeInCompanyMin())
                    {
                        employeesProgressValids.Add(_employee);
                    }
                }
            }else
            {
                //Valida que a quantidade de pessoas que querem promover não tem disponivel para a quantidade de funcionarios aptos a promoção.
            }
            return employeesProgressValids;
        }

        public List<Employee> GetEmployeeInCompany(int company)
        {
            return _employeeRepository.GetEmployeeInCompany(company);
        }

        public List<Employee> GetEmployeeForProgress(int quantity)
        {
            return null;

        }

        public static List<Employee> BubbleSort(List<Employee> employees)
        {
            int lenght = employees.Count;
            int comparation = 0;

            for (int i = lenght - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    comparation++;
                    if (employees[j].PLevel < employees[j + 1].PLevel)
                    {
                        Employee aux = employees[j];
                        employees[j] = employees[j + 1];
                        employees[j + 1] = aux;
                    }
                }
            }

            return employees;
        }


        public int GetPointsPromotion()
        {
            return PointOfCompany + GetPointOfProgression() + GetPointOfAge();
        }

        private bool GetIsTimeInCompanyMin()
        {
            if (GetIsValidateToProgress())
            {
                return !(GetIsTimeValideCompany() < 2 && _employee.PLevel == 4);
            }
            return false;
        }

        private int GetPointOfAge()
        {
            int age = DateTime.Now.Year - _employee.BirthYear;
            return age % 5;
        }

        private int PointOfCompany => GetIsTimeValideCompany() % 2;

        private int GetPointOfProgression()
        {
            int timeOfProgression = DateTime.Now.Year - _employee.LastProgressionYear;
            return timeOfProgression % 3;
        }

        private int GetIsTimeValideCompany()
        {
            int quantityYearsInCompany = DateTime.Now.Year - _employee.AdmissionYear;
            return quantityYearsInCompany;
        }

        public bool GetIsValidateToProgress()
        {
            return GetIsTimeValideCompany() > 1;
        }

        public static List<Employee> GetEmployees()
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
            return employeers;
        }
    }
}
