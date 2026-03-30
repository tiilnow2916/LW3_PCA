using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IRegistrationDAO
    {
        RentRegistration? Get(int id);
        void Add(RentRegistration rentRegistration); 
        int IndexOf(RentRegistration rentRegistration);
        RentRegistration this[int i] { get; set; }
        IEnumerable<RentRegistration> GetList();
        public void RegisterRent(Auto auto, Client client);
        public void RegisterReturn(Auto auto, Client client);

        public int GenerateNewId();
        public IEnumerable<RentRegistration> GetAllRegistrations();

    }
}
