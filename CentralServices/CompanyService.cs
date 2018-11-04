using CenterEntities;
using CenterIRepository;
using CenterIService;
using System.Collections.Generic;

namespace CentralServices
{
    public class CompanyService
    {
        private readonly EmployeeService _employeeService;
        private Employee Employee { get; set; }

        public CompanyService()
        {
            _employeeService = new EmployeeService();
        }

        public List<Employee> GetProgressEmployee(int quantityProgress, int company)
        {
            List<Employee> employees = _employeeService.GetEmployeeInCompany(company);
            //_employeeService
            return null;
        }



    }
}
