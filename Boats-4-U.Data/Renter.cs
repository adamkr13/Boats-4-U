using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Data
{
    public class Renter
    {
        [Key]
        public int RenterId { get; set; }

        [Required]
        public Guid ApplicationUser { get; set; }

        [Required]
        public string RenterFirstName { get; set; }

        [Required]
        public string RenterLastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string CreditCardNumber { get; set; }

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

        public int RenterAge
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        public virtual List<Reservation> ReservationRenter { get; set; } = new List<Reservation>();
    }
}
