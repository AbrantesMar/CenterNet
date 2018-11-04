using CenterEntities;
using CenterIRepository;
using CenterIService;
using CenterRepository;
using System.Collections.Generic;

namespace CentralServices
{
    public class ClientService 
    {
        private ClientRepository clientRepository;
        public Client Time;

        public ClientService()
        {
            Time = new Client();
        }


        public void FormulateTime(List<Client> clientes, List<Employee> employeesParams)
        {
            List<Employee> employees = new List<Employee>();
            foreach (var item in employeesParams)
            {
                employees.Add(item);
            }
            List<int> empId = new List<int>();
            for (int i = 0, clientCount = clientes.Count - 1; i <= clientCount; clientCount--)
            {
                Client client = clientes[clientCount];
                for (int j = 0; j < employees.Count; j++)
                {
                    Employee employee = employees[j];
                    if (empId.Contains(employee.Id))
                        continue;
                    if (client.Time.Count > 0)
                    {
                        if (ValidateMaturity(employee.PLevel, client.MinMaturity, client.EmployeesCount, clientCount))
                        {
                            TimeAdd(employee, employees, client.Time, empId);
                            j = j - 1;
                        }
                        else if (client.EmployeesCount <= 0) break;
                    }
                    else if (employee.PLevel <= client.MinMaturity || (employee.PLevel >= client.MinMaturity && clientCount == 0))
                    {
                        TimeAdd(employee, employees, client.Time, empId);
                        j = j - 1;
                    }
                }
                clientes[clientCount] = client;
            }
        }

        private void TimeAdd(Employee employee, List<Employee> employees, List<Employee> time, List<int> empId)
        {
            time.Add(employee);
            empId.Add(employee.Id);
            employees.Remove(employee);
        }

        private bool ValidateMaturity(int level, int minMaturity, int employeesCount, int clientCount)
        {
            bool toBack = false;
            if (level == employeesCount)
            {
                toBack = true;
            }
            else if (level > employeesCount && clientCount == 0)
            {
                toBack = true;
            }
            return toBack;
        }

        public void MergeRevert(List<Client> clients)
        {
            Employee jrEmp = new Employee();
            Employee seniorEmp = new Employee();
            clients.Sort((x, y) => x.EmployeesCount.CompareTo(y.EmployeesCount));

            for (int i = 0, count = clients.Count, backCount = clients.Count - 1; i < clients.Count; i++)
            {
                Client client = clients[i];
                if (i != backCount)
                {
                    Client clientNext = clients[i + 1];
                    if (client.EmployeesCount < 0)
                    {
                        if (client.MinMaturity > clientNext.MinMaturity)
                        {
                            AddNext(client, clientNext);
                        }
                        else
                        {
                            if (client.EmployeesCount < clientNext.EmployeesCount)
                            {
                                AddSeniorClient(clientNext, client, clientNext.Time.Count - 1, false);
                            }
                        }
                    }
                    else
                    {
                        if (i > 0)
                        {
                            Client clientBack = clients[i - 1];
                            while (client.MinMaturity > clientBack.MinMaturity && client.MaxMaturity <= clientBack.MaxMaturity)
                            {
                                AddSenior(client, clientBack, clientBack.Time.Count - 1, true);
                            }
                        }
                    }
                    clients[i] = client;
                    clients[i + 1] = clientNext;
                }
                else
                {
                    Client clientNext = clients[i - 1];
                    if (client.EmployeesCount < 0)
                    {
                        if (client.MinMaturity > clientNext.MinMaturity)
                        {
                            AddSeniorClient(client, clientNext, 0, false);
                        }
                    }
                    else
                    {
                        if (i > 0)
                        {
                            Client clientBack = clients[i - 1];
                            while ((client.MinMaturity > clientBack.MinMaturity && client.MaxMaturity <= clientBack.MaxMaturity) || (clientBack.MinMaturity > clientBack.MaxMaturity))
                            {
                                if ((clientBack.MinMaturity > clientBack.MaxMaturity))
                                {
                                    AddNext(clientNext, client);
                                }
                                else
                                {
                                    AddSenior(client, clientNext, clientNext.Time.Count - 1, true);
                                }
                            }
                        }
                    }
                    clients[i] = client;
                    clients[i - 1] = clientNext;
                }
            }

            clients.Sort((x, y) => x.MinMaturity.CompareTo(y.MinMaturity));
            for (int i = 0; i < clients.Count; i++)
            {
                if ((i > 0) && (i <= (clients.Count - 2)))
                {
                    if (clients[i].MinMaturity > clients[i + 1].MinMaturity && ((clients[i].EmployeesCount > clients[i + 1].EmployeesCount) || (clients[i].EmployeesCount > clients[i - 1].EmployeesCount))) MergeRevert(clients);
                    else if (!(clients[i].MinMaturity > clients[i + 1].MinMaturity) && ((clients[i].EmployeesCount < clients[i + 1].EmployeesCount)))
                    {
                        MergeRevert(clients);
                    }
                }
                else if (i == 0)
                {
                    if (!(clients[i].MinMaturity > clients[i + 1].MinMaturity) && ((clients[i].EmployeesCount < clients[i + 1].EmployeesCount)))
                    {
                        MergeRevert(clients);
                    }
                }

            }
        }

        private void AddNext(Client client, Client clientNext)
        {
            Employee jrEmp = new Employee();
            Employee seniorEmp = new Employee();
            client.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
            seniorEmp = clientNext.Time[0];
            jrEmp = client.Time[client.Time.Count - 1];

            client.Time.Remove(jrEmp);
            clientNext.Time.Remove(seniorEmp);
            client.Time.Add(seniorEmp);
            clientNext.Time.Add(jrEmp);
        }

        private void AddSenior(Client client, Client clientNext, int position, bool addClient)
        {
            Employee jrEmp = new Employee();
            client.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
            clientNext.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
            jrEmp = clientNext.Time[position];
            if (addClient)
            {
                clientNext.Time.Remove(jrEmp);
                client.Time.Add(jrEmp);
            }
            else
            {
                client.Time.Remove(jrEmp);
                clientNext.Time.Add(jrEmp);
            }
        }

        private void AddSeniorClient(Client client, Client clientNext, int position, bool addClient)
        {
            Employee jrEmp = new Employee();
            client.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
            clientNext.Time.Sort((x, y) => x.PLevel.CompareTo(y.PLevel));
            jrEmp = client.Time[position];
            if (addClient)
            {
                clientNext.Time.Remove(jrEmp);
                client.Time.Add(jrEmp);
            }
            else
            {
                client.Time.Remove(jrEmp);
                clientNext.Time.Add(jrEmp);
            }
        }

        public List<Client> GetClientByFile()
        {
            List<Client> clients;
            if (clientRepository != null)
            {
                clients = clientRepository.GetClientsByFile();
            }
            else
            {
                clients = new List<Client>()
                    {
                        new Client
                        {
                            Id = 1,
                            Description = "Cliente 1",
                            Time = new List<Employee>(),
                            MinMaturity = 3
                        },
                        new Client
                        {
                            Id = 2,
                            Description = "Cliente 2",
                            Time = new List<Employee>(),
                            MinMaturity = 5
                        },
                        new Client
                        {
                            Id = 3,
                            Description = "Cliente 3",
                            Time = new List<Employee>(),
                            MinMaturity = 7
                        }
                    };
            }
            return clients;
        }
    }
}
