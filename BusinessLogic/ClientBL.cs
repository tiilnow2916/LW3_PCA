using System;
using System.Collections.Generic;
using System.Linq;
using DataService;
using Entities;

namespace BusinessLogic
{
    public class ClientBL
    {
        private readonly IClientDAO clientsDAO;

        public ClientBL()
        {
            clientsDAO = new ClientServices();
        }

        public void Add(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null");
            }

            var existingClient = clientsDAO.Get(client.FirstName, client.LastName);
            if (existingClient != null)
            {
                throw new InvalidOperationException(
                    $"Client {client.FirstName} {client.LastName} already exists");
            }

            if (string.IsNullOrWhiteSpace(client.FirstName))
            {
                throw new ArgumentException("First name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(client.LastName))
            {
                throw new ArgumentException("Last name cannot be empty");
            }
            if (client.CarRights < 0)
            {
                throw new ArgumentException("Car rights must be non-negative");
            }

            clientsDAO.Add(client);
        }

        public void Delete(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null");
            }

            var existingClient = clientsDAO.Get(client.FirstName, client.LastName);
            if (existingClient == null)
            {
                throw new InvalidOperationException("Client not found");
            }

            clientsDAO.Delete(client);
        }

        public Client? Get(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be empty");
            }
            return clientsDAO.Get(firstName, lastName);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return (IEnumerable<Client>)clientsDAO;
        }


        public void Edit(string firstName, string lastName, string newFirstName, string newLastName, int carRights)
        {
            var client = clientsDAO.Get(firstName, lastName);
            if (client == null)
            {
                throw new InvalidOperationException($"Client {firstName} {lastName} not found");
            }

            if (string.IsNullOrWhiteSpace(newFirstName))
            {
                throw new ArgumentException("New first name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(newLastName))
            {
                throw new ArgumentException("New last name cannot be empty");
            }
            if (carRights < 0)
            {
                throw new ArgumentException("Car rights must be non-negative");
            }

            if (newFirstName != firstName || newLastName != lastName)
            {
                var existingClient = clientsDAO.Get(newFirstName, newLastName);
                if (existingClient != null)
                {
                    throw new InvalidOperationException(
                        $"Client {newFirstName} {newLastName} already exists");
                }
            }

            client.FirstName = newFirstName;
            client.LastName = newLastName;
            client.CarRights = carRights;
        }

        public void Edit(string firstName, string lastName, int carRights)
        {
            var client = clientsDAO.Get(firstName, lastName);
            if (client == null)
            {
                throw new InvalidOperationException($"Client {firstName} {lastName} not found");
            }

            if (carRights < 0)
            {
                throw new ArgumentException("Car rights must be non-negative");
            }

            client.CarRights = carRights;
        }


        public IEnumerable<Client> GetByCarRights(int carRights)
        {
            if (carRights < 0)
            {
                throw new ArgumentException("Invalid rights number");
            }
            return clientsDAO.GetList()
                .Where(x => x.CarRights == carRights);
        }

        public IEnumerable<Client> GetAllByFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be empty");
            }
            return clientsDAO.GetList()
                .Where(x => x.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Client> GetAllByLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be empty");
            }
            return clientsDAO.GetList()
                .Where(x => x.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }


        public IEnumerable<Client> SortByFirstNameAsc()
        {
            return clientsDAO.GetList().OrderBy(x => x.FirstName);
        }

        public IEnumerable<Client> SortByFirstNameDesc()
        {
            return clientsDAO.GetList().OrderByDescending(x => x.FirstName);
        }

        public IEnumerable<Client> SortByLastNameAsc()
        {
            return clientsDAO.GetList().OrderBy(x => x.LastName);
        }

        public IEnumerable<Client> SortByLastNameDesc()
        {
            return clientsDAO.GetList().OrderByDescending(x => x.LastName);
        }



        public IEnumerable<Client> GetAll()
        {
            return clientsDAO.GetList();
        }


        public Client this[int i]
        {
            get => clientsDAO[i];
            set => clientsDAO[i] = value;
        }

        public int IndexOf(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null");
            }
            return clientsDAO.IndexOf(client);
        }
    }
}