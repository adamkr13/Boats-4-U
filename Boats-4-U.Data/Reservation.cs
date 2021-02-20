using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Data
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [ForeignKey(nameof(Driver))]
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        [ForeignKey(nameof(Renter))]
        public int RenterId { get; set; }
        public virtual Renter Renter { get; set; }

        [Required]
        public int NumberOfPassengers { get; set; }

        [Required]
        public DateTimeOffset DateReservedFor { get; set; }

        [Required]
        public decimal ReservationDuration { get; set; }

        [Required]
        public DateTimeOffset DateReservationMade { get; set; }

        [Required]
        public Guid User { get; set; }

        public string ReservationDetails { get; set; }

        public decimal EstimatedTotalCost
        {
            get
            {
                var estimatedTotalCost = Driver.HourlyRate * ReservationDuration;
                return estimatedTotalCost;
            }
        }

        public string DisplayDateReservedFor
        {
            get
            {
                var date = DateReservedFor;
                string fmt = "D";
                var displayDate = date.Date.ToString(fmt);
                return displayDate;
            }
        }

        public string DisplayDateReservationMade
        {
            get
            {
                var date = DateReservedFor;
                string fmt = "D";
                var displayDate = date.Date.ToString(fmt);
                return displayDate;
            }
        }

        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
