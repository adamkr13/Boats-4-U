using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.Renter
{
    public class RenterUpdate
    {
        public int RenterId { get; set; }
        public string RenterFirstName { get; set; }
        public string RenterLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CreditCardNumber { get; set; }
    }
}
