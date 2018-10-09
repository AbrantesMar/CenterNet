using System.Collections.Generic;

namespace CenterEntities
{
    public class Company : Base
    {
        public List<Client> Clientes { get; set; }
        public Time Time { get; set; }
    }
}
