using DataService;
using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClientServices : IClientDAO, IEnumerable<Client>
    {
        public List<Client> clients = new();
        public Client this[int i] 
        { 
            get { return clients[i]; }
            set { clients[i] = value; }
        }

        public void Add(Client client)
        {
            if (client == null)
               throw new ArgumentNullException("Client not exists");
            clients.Add(client);
        }

        public void Delete(Client client)
        {
            if (client == null)
                throw new ArgumentNullException("Client not exists");
            clients.Remove(client);
        }

        public void Edit(string firstName, string lastName, int carRights)
        {
            var client = Get(firstName, lastName);
            if (client != null)
            {
                int rewIndex = IndexOf(Get(firstName, lastName));
                this[rewIndex].FirstName = firstName;
                this[rewIndex].FirstName = firstName;
                this[rewIndex].CarRights = carRights;

            }
        }

        public Client Get(string firstName, string lastName)
        {
            return clients.Find(x => x.FirstName == firstName && x.LastName == lastName);

        }

        public IEnumerator<Client> GetEnumerator()
        {
            return clients.GetEnumerator();
        }

        public IEnumerable<Client> GetList()
        {
            return clients;
        }

        public int IndexOf(Client client)
        {
            if (clients == null)
            {
                throw new ArgumentNullException("Client not exist!");
            }
            return clients.IndexOf(client);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
