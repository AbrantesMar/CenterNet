using CenterEntities;
using CenterIRepository;

namespace CenterRepository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository()
        {
        }
    }
}
