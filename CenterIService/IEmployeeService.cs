using CenterEntities;
using System.Collections.Generic;

namespace CenterIService
{
    public interface IEmployeeService : IService<Employee>
    {
        List<Employee> GetEmployeeInCompany(int company);
        List<Employee> BubbleSort(List<Employee> employees);
    }
}
