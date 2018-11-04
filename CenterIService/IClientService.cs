using CenterEntities;
using System.Collections.Generic;

namespace CenterIService
{
    public interface IClientService : IService<Client>
    {
        void FormulateTime(List<Client> clientes);
        void MergeRevert(List<Client> clients);
        List<Client> GetClientByFile();
    }
}
