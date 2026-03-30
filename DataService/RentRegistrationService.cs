using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using Entities;

namespace DataService
{
    public class RentRegistrationService : IRegistrationDAO, IEnumerable<RentRegistration>
    {
        public List<RentRegistration> rentRegistrations= new();

        public RentRegistration this[int i]
        {
            get { return rentRegistrations[i]; }
            set { rentRegistrations[i] = value; }
        }

        public void Add(RentRegistration rentRegistration)
        {
            if (rentRegistration == null)
            {
                throw new ArgumentNullException("RentRegistration not exists");
            }
            rentRegistrations.Add(rentRegistration);
        }

        public RentRegistration? Get(int id)
        {
            return rentRegistrations.Find(x => x.Id == id);
        }

        public IEnumerator<RentRegistration> GetEnumerator()
        {
            return rentRegistrations.GetEnumerator();
        }

        public IEnumerable<RentRegistration> GetList()
        {
            return rentRegistrations;
        }

        public int IndexOf(RentRegistration rentRegistration)
        {
            if (rentRegistration == null)
            {
                throw new ArgumentNullException("Reward not exists");
            }
            return rentRegistrations.IndexOf(rentRegistration);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
