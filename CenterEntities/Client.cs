using System.Collections.Generic;

namespace CenterEntities
{
    public class Client : Base
    {
        public List<Employee> Time { get; set; }
        public int MinMaturity { get; set; }
        public int MaxMaturity { get; set; }

        public int EmployeesCount
        {
            get
            {
                int count = 0;
                foreach (var time in Time)
                {
                    count =+ time.PLevel;
                }
                return count;
            }
        }
    }
}
