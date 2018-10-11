using CenterEntities;
using CenterIRepository;
using System;
using System.Collections.Generic;

namespace CentralServices
{   
    public class EmployeeService : Service<Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private Employee _employee;

        public EmployeeService(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

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
            int timeOfProgression = DateTime.Now.Year - _employee.LastProgressionYear.Year;
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
    }
}
