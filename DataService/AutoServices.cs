using DataService;
using Entities;
using System.Collections;

namespace DataService
{
    public class AutoServices : IAutoDAO, IEnumerable<Auto>
    {
        public List<Auto> availableAutos = new();
        public List<Auto> unavailableAutos = new();

        public Auto this[int i]
        {
            get
            {
                if (i < 0 || i >= availableAutos.Count)
                {
                    throw new IndexOutOfRangeException($"Index {i} out of range. Available cars count: {availableAutos.Count}");
                }
                return availableAutos[i];
            }
            set
            {
                if (i < 0 || i >= availableAutos.Count)
                {
                    throw new IndexOutOfRangeException($"Index {i} out of range. Available cars count: {availableAutos.Count}");
                }
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Auto cannot be null");
                }
                availableAutos[i] = value;
            }
        }

        public int IndexOf(Auto auto)
        {
            if (auto == null)
            {
                throw new ArgumentNullException(nameof(auto), "Auto cannot be null");
            }
            return availableAutos.IndexOf(auto);
        }

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

        public void Edit(int passengerNumber, int engineCapacity, double mileage,
                 int releaseYear, int registrationNumber,
                 double insuranceSumm, double rentCost)
        {
            var auto = GetByRegistrationNumber(registrationNumber);
            if (auto != null)
            {
                auto.PassengerNumber = passengerNumber;
                auto.EngineCapacity = engineCapacity;
                auto.Mileage = mileage;
                auto.ReleaseYear = releaseYear;
                auto.RegistrationNumber = registrationNumber;
                auto.InsuranceSumm = insuranceSumm;
                auto.RentCost = rentCost;
            }
        }

        public IEnumerable<Auto> GetAllByPassengerNumber(int passNumber)
        {
            return availableAutos.FindAll(x => x.PassengerNumber == passNumber);
        }
        public IEnumerable<Auto> GetAllByReleaseYear(int releaseYear)
        {
            return availableAutos.FindAll(x => x.ReleaseYear == releaseYear);
        }
        public Auto? GetByRegistrationNumber(int regNumber)
        {
            return availableAutos.Find(x => x.RegistrationNumber == regNumber);
        }
        public IEnumerable<Auto> GetAllByRentalCost(double rentCost)
        {
            return availableAutos.FindAll(x => x.RentCost == rentCost);
        }
        public IEnumerable<Auto> GetAllByEngineCapacity(int engineCapacity)
        {
            return availableAutos.FindAll(x => x.EngineCapacity == engineCapacity);
        }
        public IEnumerable<Auto> GetAllByMileage(double mileage)
        {
            return availableAutos.FindAll(x => x.Mileage == mileage);
        }

        public IEnumerable<Auto> GetListOfAvailableCars()
        {
            return availableAutos;
        }
        public IEnumerable<Auto> GetListOfUnavailableCars()
        {
            return unavailableAutos;
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
        public void RemoveFromAvailable(Auto auto)
        {
            if (auto == null)
            {
                throw new ArgumentNullException("Auto not exists");
            }
            availableAutos.Remove(auto);
            unavailableAutos.Add(auto);
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
