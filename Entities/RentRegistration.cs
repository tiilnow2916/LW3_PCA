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
        public RentActionType TypeOfAction { get; set; }
        public Client Client { get; set; }
        public Auto Auto { get; set; }

    }
}
