using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models
{
    public class RenterListItem
    {
        public int RenterId { get; set; }

        public Guid User { get; set; }

        public string RenterFirstName { get; set; }

        public string RenterLastName { get; set; }

        public string RenterFullName { get; set; }

        public int RenterAge { get; set; }

        public long CreditCardNumber { get; set; }

        public int Last4Digits { get; set; }

    }
}
