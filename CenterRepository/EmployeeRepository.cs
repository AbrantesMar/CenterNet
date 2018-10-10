using CenterEntities;
using System.Collections.Generic;

namespace CenterRepository
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public List<Employee> GetEmployeeInCompany(int company)
        {
            return new List<Employee>();
        }
    }
}
