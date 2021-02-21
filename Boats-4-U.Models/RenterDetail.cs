using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models
{
    public class RenterDetail
    {
        public int RenterId { get; set; }
        public string RenterFirstName { get; set; }
        public string RenterLastName { get; set; }
        public int RenterAge { get; set; }
        public long CreditCardNumber { get; set; }
        public string RenterFullName
        {
            get
            {
                var fullName = $"{RenterFirstName} {RenterLastName}";
                return fullName;
            }
        }
        public string Last4Digits
        {
            get
            {
                var creditCardNumber = $"{CreditCardNumber}";

                return creditCardNumber.Substring(creditCardNumber.Length - 4, 4);
            }
        }
    }
}
