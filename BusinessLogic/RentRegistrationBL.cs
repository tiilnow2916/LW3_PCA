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
        public IEnumerable<RentRegistration> GetAllRegistrations()
        {
            return (IEnumerable<RentRegistration>)registrationsDAO;
        }
        public void RegisterRent(Auto auto, Client client)
        {
            if (auto == null)
                throw new ArgumentNullException(nameof(auto), "Auto cannot be null");

            if (client == null)
                throw new ArgumentNullException(nameof(client), "Client cannot be null");

            var rentRegistration = new RentRegistration
            {
                Id = GenerateNewId(),
                DateOfAction = DateOnly.FromDateTime(DateTime.Now),
                TypeOfAction = RentActionType.Rent,
                Client = client,
                Auto = auto
            };

            registrationsDAO.Add(rentRegistration);
        }
        public void RegisterReturn(Auto auto)
        {
            if (auto == null)
                throw new ArgumentNullException(nameof(auto), "Auto cannot be null");

            var lastRent = registrationsDAO.GetAllRegistrations()
                .Where(r => r.Auto.RegistrationNumber == auto.RegistrationNumber &&
                           r.TypeOfAction == RentActionType.Rent)
                .OrderByDescending(r => r.DateOfAction)
                .FirstOrDefault();

            if (lastRent == null)
            {
                throw new InvalidOperationException($"No active rent found for car {auto.RegistrationNumber}");
            }

            var returnRegistration = new RentRegistration
            {
                Id = GenerateNewId(),
                DateOfAction = DateOnly.FromDateTime(DateTime.Now),
                TypeOfAction = RentActionType.Return,
                Client = lastRent.Client, 
                Auto = auto
            };

            registrationsDAO.Add(returnRegistration);
        }
        private int GenerateNewId()
        {
            var allRegistrations = registrationsDAO.GetAllRegistrations();
            return allRegistrations.Any() ? allRegistrations.Max(r => r.Id) + 1 : 1;
        }
    }
}
