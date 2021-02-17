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
        public string RenterFirstName { get; set; }

        [Required]
        public string RenterLastName { get; set; }

        [Required]
        public int RenterAge { get; set; }

        [Required]
        public long CreditCardNumber { get; set; }

        [Required]
        public Guid User { get; set; }

        public virtual List<Reservation> ReservationRenter { get; set; } = new List<Reservation>();
    }
}
