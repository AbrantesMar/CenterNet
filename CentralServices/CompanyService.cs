using CenterEntities;
using CenterIService;
using System.Collections.Generic;

namespace CentralServices
{
    public class CompanyService : Service<Company>
    {
        private readonly IEmployeeService _employeeService;
        public CompanyService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public List<Employee> GetProgressEmployee(int quantityProgress, int company)
        {
            List<Employee> employees = _employeeService.GetEmployeeInCompany(company);
            _employeeService
            return null;
        }

    }
}
