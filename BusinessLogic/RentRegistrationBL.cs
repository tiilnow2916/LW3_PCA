using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using Entities;
namespace BusinessLogic
{
    public class RentRegistrationBL
    {
        private readonly IRegistrationDAO registrationsDAO;
        public RentRegistrationBL ()
        {
            registrationsDAO = new RentRegistrationService ();
        }
        public void Add(RentRegistration registration)
        {
            if (registration == null)
            {
                throw new ArgumentNullException(nameof(registration), "Registration cannot be null");
            }

            registrationsDAO.Add(registration);
        }
        public RentRegistration? GetByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID number must be positive");
            }
            return registrationsDAO.Get(id);
        }

    }
}
