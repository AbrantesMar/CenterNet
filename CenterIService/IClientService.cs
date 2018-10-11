using CenterEntities;
using System.Collections.Generic;

namespace CenterIService
{
    public interface IClientService : IService<Client>
    {
        List<Employee> GetEmployees();
    }
}
