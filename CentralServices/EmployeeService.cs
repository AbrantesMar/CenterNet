using CenterEntities;
using CenterIRepository;
using System;
using System.Collections.Generic;

namespace CentralServices
{
    public class EmployeeService : Service<Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly Employee _employee;

        public Employee Progression(List<Employee> employees)
        {
            //List<Employee> _employee = _employeeRepository.GetAll();
            //if()
            //TODO: add logica para progressão

            bubbleSort(employees);

            return null;
        }

        public List<Employee> GetEmployeeInCompany(int company)
        {
            return _employeeRepository.GetEmployeeInCompany(company);
        }

        public List<Employee> GetEmployeeForProgress(int quantity)
        {
            return null;

        }

        public static List<Employee> bubbleSort(List<Employee> vetor)
        {
            int lenght = vetor.Count;
            int comparation = 0;

            for (int i = lenght - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    comparation++;
                    if (vetor[j].PLevel > vetor[j + 1].PLevel)
                    {
                        Employee aux = vetor[j];
                        vetor[j] = vetor[j + 1];
                        vetor[j + 1] = aux;
                    }
                }
            }

            return vetor;
        }


        public int GetPointsPromotion()
        {
            return PointOfCompany + GetPointOfProgression() + GetPointOfAge();
        }

        private int GetPointOfAge()
        {
            int age = DateTime.Now.Year - _employee.BirthYear.Year;
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
            int quantityYearsInCompany = DateTime.Now.Year - _employee.AdmissionYear.Year;
            return quantityYearsInCompany;
        }

        private bool GetIsTimeInCompanyMin()
        {
            return !(GetIsTimeValideCompany() < 2 && _employee.PLevel == 4);
        }

        public bool GetIsValidateToProgress()
        {
            return GetIsTimeValideCompany() > 1;
        }
    }
}
