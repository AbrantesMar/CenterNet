using CenterEntities;
using System.Collections.Generic;

namespace CenterIRepository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        List<Employee> GetEmployeeInCompany(int company);
    }
}
