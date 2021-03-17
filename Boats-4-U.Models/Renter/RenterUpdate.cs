using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.Renter
{
    public class RenterUpdate
    {
        [Required]
        public int RenterId { get; set; }
        [Required]
        public string RenterFirstName { get; set; }
        [Required]
        public string RenterLastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string CreditCardNumber { get; set; }
    }
}
