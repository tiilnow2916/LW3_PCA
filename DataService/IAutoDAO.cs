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
        public Auto? GetByPassengerNumber(int passNumber);
        public Auto? GetByReleaseYear(int releaseYear);
        public Auto? GetByRegistrationNumber(int regNumber);
        public Auto? GetByRentalCost(int rentCost);
        public Auto? GetByEngineCapacity(int engineCapacity);
        public Auto? GetByMileage(int mileage);
        int IndexOf(Auto auto);
        Auto this[int i] { get; set; }
        public IEnumerable<Auto> GetListOfAvailableCars();
        public IEnumerable<Auto> GetListOfUnavailableCars();
        void Edit(int passengerNumber, int engineCapacity, double mileage, int releaseYear, int registrationNumber, double insuranceSumm, double rentCost);
    }
}
