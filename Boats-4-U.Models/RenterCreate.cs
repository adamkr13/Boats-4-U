using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models
{
    public class RenterCreate
    {
        [Required]
        public string RenterFirstName { get; set; }

        [Required]
        public string RenterLastName { get; set; }

        [Required]
        public int RenterAge { get; set; }

        [Required]
        [MinLength(16, ErrorMessage = "Please Enter a Valid 16 Digit Credit Card Number")]
        [MaxLength(16, ErrorMessage = "Please Enter a Valid 16 Digit Credit Card Number")]
        public long CreditCardNumber { get; set; }

    }
}
