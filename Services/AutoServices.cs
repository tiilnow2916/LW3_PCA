using DataService;
using Entities;
using System.Collections;

namespace Services
{
    public class AutoServices : IAutoDAO, IEnumerable<Auto>
    {
        public List<Auto> availableAutos = new();
        public List<Auto> unavailableAutos = new();
        
        public Auto this[int i] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(Auto auto)
        {
            if (auto == null)
            {
                throw new ArgumentNullException("Auto not exists");
            }
            availableAutos.Add(auto);
        }
        public void AddToAvailable(Auto auto)
        {
            if (auto == null)
            {
                throw new ArgumentNullException("Auto not exists");
            }
            availableAutos.Add(auto);

        }

        public void AddToUnavailable(Auto auto)
        {
            if (auto == null)
            {
                throw new ArgumentNullException("Auto not exists");
            }
            availableAutos.Remove(auto);
            unavailableAutos.Add(auto);
        }

        public void Delete(Auto auto)
        {
            if (auto == null)
            {
                throw new ArgumentNullException("Auto not exists");
            }
            availableAutos.Remove(auto);
        }

        public void Edit(int passengerNumber, int engineCapacity, double mileage, int releaseYear, int registrationNumber, double insuranceSumm, double rentCost)
        {
            var auto = GetByRegistrationNumber(registrationNumber);
            if (auto != null)
            {
                int rewIndex = IndexOf(GetByRegistrationNumber(registrationNumber));
                this[rewIndex].PassengerNumber = passengerNumber;
                this[rewIndex].EngineCapacity = engineCapacity;
                this[rewIndex].Mileage = mileage;
                this[rewIndex].ReleaseYear = releaseYear;
                this[rewIndex].RegistrationNumber = registrationNumber;
                this[rewIndex].InsuranceSumm = insuranceSumm;
                this[rewIndex].RentCost = rentCost;


            }
        }

        public Auto? GetByPassengerNumber(int passNumber)
        {
            return availableAutos.Find(x => x.PassengerNumber == passNumber);
        }
        public Auto? GetByReleaseYear(int releaseYear)
        {
            return availableAutos.Find(x => x.ReleaseYear == releaseYear);
        }
        public Auto? GetByRegistrationNumber(int regNumber)
        {
            return availableAutos.Find(x => x.RegistrationNumber == regNumber);
        }
        public Auto? GetByRentalCost(int rentCost)
        {
            return availableAutos.Find(x => x.RentCost == rentCost);
        }
        public Auto? GetByEngineCapacity(int engineCapacity)
        {
            return availableAutos.Find(x => x.EngineCapacity == engineCapacity);
        }
        public Auto? GetByMileage(int mileage)
        {
            return availableAutos.Find(x => x.Mileage == mileage);
        }

        public IEnumerable<Auto> GetListOfAvailableCars()
        {
            return availableAutos;
        }
        public IEnumerable<Auto> GetListOfUnavailableCars()
        {
            return unavailableAutos;
        }

        public int IndexOf(Auto auto)
        {
            if (availableAutos == null)
            {
                throw new ArgumentNullException("Auto not exist!");
            }
            return availableAutos.IndexOf(auto);
        }

        public void RemoveFromUnavailable(Auto auto)
        {
            if (auto == null)
            {
                throw new ArgumentNullException("Auto not exists");
            }
            unavailableAutos.Remove(auto);
            availableAutos.Add(auto);
        }

        public IEnumerator<Auto> GetEnumerator()
        {
            return availableAutos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
