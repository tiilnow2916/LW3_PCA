using Entities;
namespace DataService
{
    public interface IAutoDAO
    {
        void AddToUnavailable(Auto auto);
        void AddToAvailable(Auto auto);
        void RemoveFromUnavailable(Auto auto);
        void Add(Auto auto);
        void Delete(Auto auto);
        public IEnumerable<Auto> GetAllByPassengerNumber(int passNumber);
        public IEnumerable<Auto> GetAllByReleaseYear(int releaseYear);
        public Auto? GetByRegistrationNumber(int regNumber);
        public IEnumerable<Auto> GetAllByRentalCost(int rentCost);
        public IEnumerable<Auto> GetAllByEngineCapacity(int engineCapacity);
        public IEnumerable<Auto> GetAllByMileage(int mileage);
        int IndexOf(Auto auto);
        Auto this[int i] { get; set; }
        public IEnumerable<Auto> GetListOfAvailableCars();
        public IEnumerable<Auto> GetListOfUnavailableCars();
        void Edit(int passengerNumber, int engineCapacity, double mileage, int releaseYear, int registrationNumber, double insuranceSumm, double rentCost);
    }
}
