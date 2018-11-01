using CenterEntities;
using CenterIRepository;
using CenterIService;
using System.Collections.Generic;

namespace CentralServices
{
    public class ClientService : Service<Client>
    {

        public Client Time;

        public ClientService(IBaseRepository<Client> repository) : base(repository)
        {
            Time = new Client();
        }

        public void GetTime(List<Employee> employeesInBench)
        {
            List<Employee> possibility = new List<Employee>();
            int factor = 0;
            for (int i = 0, count = employeesInBench.Count; i < count; i++)
            {
                if(Time.MinMaturity < employeesInBench[i].PLevel && Time.MaxMaturity > employeesInBench[i].PLevel)
                {
                    if (possibility.Count < 0)
                    {
                        for (int j = 0; j < possibility.Count; j++)
                        {
                            factor = (possibility[j].PLevel + employeesInBench[i].PLevel);
                            
                        }
                        if (factor > Time.MinMaturity && factor < Time.MaxMaturity)
                        {
                            employeesInBench[i].Client = Time;
                            possibility.Add(employeesInBench[i]);
                        }
                    }
                }
            }

        }
    }
}
