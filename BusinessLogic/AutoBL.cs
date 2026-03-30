using DataService;
using Entities;

namespace BusinessLogic
{
    public class AutoBL
    {
        private readonly IAutoDAO autosDAO;

        public AutoBL()
        {
            autosDAO = new AutoServices();
        }


        public void Add(Auto auto)
        {
            if (auto == null)
            {
                throw new ArgumentNullException(nameof(auto), "Auto cannot be null");
            }

            if (autosDAO.GetByRegistrationNumber(auto.RegistrationNumber) != null)
            {
                throw new InvalidOperationException(
                    $"Auto with registration number {auto.RegistrationNumber} already exists");
            }

            if (auto.PassengerNumber <= 0)
            {
                throw new ArgumentException("Passenger number must be positive");
            }
            if (auto.RentCost <= 0)
            {
                throw new ArgumentException("Rent cost must be positive");
            }

            autosDAO.Add(auto);
        }

        public void Delete(Auto auto)
        {
            if (auto == null)
            {
                throw new ArgumentNullException(nameof(auto), "Auto cannot be null");
            }

            var existingAuto = autosDAO.GetByRegistrationNumber(auto.RegistrationNumber);
            if (existingAuto == null)
            {
                throw new InvalidOperationException("Auto not found");
            }

            autosDAO.Delete(auto);
        }

        public Auto? GetByRegistrationNumber(int registrationNumber)
        {
            if (registrationNumber <= 0)
            {
                throw new ArgumentException("Registration number must be positive");
            }
            return autosDAO.GetByRegistrationNumber(registrationNumber);
        }


        public void RentAuto(Auto auto)
        {
            if (auto == null)
            {
                throw new ArgumentNullException(nameof(auto), "Auto cannot be null");
            }

            var availableCars = autosDAO.GetListOfAvailableCars();
            if (!availableCars.Contains(auto))
            {
                throw new InvalidOperationException("Auto is not available for rent");
            }
            autosDAO.RemoveFromAvailable(auto);
            autosDAO.AddToUnavailable(auto);
        }

        public void ReturnAuto(Auto auto)
        {
            if (auto == null)
            {
                throw new ArgumentNullException(nameof(auto), "Auto cannot be null");
            }

            var unavailableCars = autosDAO.GetListOfUnavailableCars();
            if (!unavailableCars.Contains(auto))
            {
                throw new InvalidOperationException("Auto is not rented");
            }

            autosDAO.RemoveFromUnavailable(auto);
        }

        public void Edit(int registrationNumber, int passengerNumber, int engineCapacity,
                         double mileage, int releaseYear, double insuranceSumm, double rentCost)
        {
            var auto = autosDAO.GetByRegistrationNumber(registrationNumber);
            if (auto == null)
            {
                throw new InvalidOperationException($"Auto with registration number {registrationNumber} not found");
            }

            if (passengerNumber <= 0)
                throw new ArgumentException("Passenger number must be positive");
            if (rentCost <= 0)
                throw new ArgumentException("Rent cost must be positive");

            auto.PassengerNumber = passengerNumber;
            auto.EngineCapacity = engineCapacity;
            auto.Mileage = mileage;
            auto.ReleaseYear = releaseYear;
            auto.InsuranceSumm = insuranceSumm;
            auto.RentCost = rentCost;
        }


        public IEnumerable<Auto> GetAllByPassengerNumber(int passengerNumber)
        {
            if (passengerNumber <= 0)
            {
                throw new ArgumentException("Passenger number must be positive");
            }
            return autosDAO.GetAllByPassengerNumber(passengerNumber);
        }

        public IEnumerable<Auto> GetAllByRentalCost(double maxCost)
        {
            if (maxCost <= 0)
            {
                throw new ArgumentException("Max cost must be positive");
            }
            return autosDAO.GetAllByRentalCost(maxCost);
        }

        public IEnumerable<Auto> GetAllByRentalCost(double minCost, double maxCost)
        {
            if (minCost < 0 || maxCost < 0 || minCost > maxCost)
            {
                throw new ArgumentException("Invalid cost range");
            }
            return autosDAO.GetListOfAvailableCars()
                .Where(x => x.RentCost >= minCost && x.RentCost <= maxCost);
        }


        public IEnumerable<Auto> SortAvailableByRentCostAsc()
        {
            return autosDAO.GetListOfAvailableCars().OrderBy(x => x.RentCost);
        }

        public IEnumerable<Auto> SortAvailableByRentCostDesc()
        {
            return autosDAO.GetListOfAvailableCars().OrderByDescending(x => x.RentCost);
        }

        public IEnumerable<Auto> SortAvailableByPassengerNumberAsc()
        {
            return autosDAO.GetListOfAvailableCars().OrderBy(x => x.PassengerNumber);
        }

        public IEnumerable<Auto> SortAvailableByReleaseYearAsc()
        {
            return autosDAO.GetListOfAvailableCars().OrderBy(x => x.ReleaseYear);
        }
        public IEnumerable<Auto> SortAvailableByEngineCapacityAsc()
        {
            return autosDAO.GetListOfAvailableCars().OrderBy(x => x.EngineCapacity);
        }


        public IEnumerable<Auto> SortAvailableByMileageAsc()
        {
            return autosDAO.GetListOfAvailableCars().OrderBy(x => x.Mileage);
        }


        public IEnumerable<Auto> GetAvailableCars()
        {
            return autosDAO.GetListOfAvailableCars();
        }

        public IEnumerable<Auto> GetUnavailableCars()
        {
            return autosDAO.GetListOfUnavailableCars();
        }


        public IEnumerable<Auto> GetAll()
        {
            return autosDAO.GetListOfAvailableCars()
                .Concat(autosDAO.GetListOfUnavailableCars());
        }

        public IEnumerable<Auto> GetAvailable()
        {
            return autosDAO.GetListOfAvailableCars();
        }

        public IEnumerable<Auto> GetUnavailable()
        {
            return autosDAO.GetListOfUnavailableCars();
        }
        public Auto this[int i]
        {
            get => autosDAO[i];
            set => autosDAO[i] = value;
        }

        public int IndexOf(Auto auto)
        {
            return autosDAO.IndexOf(auto);
        }
    }
}