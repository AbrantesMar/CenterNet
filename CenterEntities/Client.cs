using System.Collections.Generic;

namespace CenterEntities
{
    public class Client : Base
    {
        public List<Employee> Time { get; set; }
        public int MinMaturity { get; set; }
        public int MaxMaturity { get; set; }
    }
}
