using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataService
{
    public interface IClientDAO
    {
        void Add(Client client);
        void Delete(Client client);
        Client Get(string firstName, string lastName);
        int IndexOf(Client client);
        Client this[int i] { get; set; }
        IEnumerable<Client> GetList();
        void Edit(string firstName, string lastName, int carRights);
    }
}
