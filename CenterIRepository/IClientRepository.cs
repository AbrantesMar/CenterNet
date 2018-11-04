using CenterEntities;
using System.Collections.Generic;

namespace CenterIRepository
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        List<Client> GetClientsByFile();
    }
}
