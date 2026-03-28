using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RentRegistration
    {
        public int Id { get; set; }
        public DateOnly DateOfAction { get; set; }
        public enum TypeOfAction { Rent, Refund }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public int CarRegistrationNumber { get; set; }

    }
}
