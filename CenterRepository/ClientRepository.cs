using CenterEntities;
using System.Collections.Generic;

namespace CenterRepository
{
    public class ClientRepository
    {
        public ClientRepository()
        {

        }

        public List<Client> GetClientsByFile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\carga\team.txt");

            var clients = new List<Client>();
            string[] lineArray;


            for (int i = 0, count = lines.Length; i < count; i++)
            {
                lineArray = lines[i].Split(',');
                var client = new Client();
                client.Id = i;
                client.Description = lineArray[0];
                int aux;
                int.TryParse(lineArray[2].Trim().ToString(), out aux);
                client.MinMaturity = aux;

                clients.Add(client);

            }

            return clients;
        }
    }
}
