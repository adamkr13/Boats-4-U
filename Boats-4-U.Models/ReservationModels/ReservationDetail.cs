using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.ReservationModels
{
    public class ReservationDetail
    {
        public int ReservationId { get; set; }

        public Guid User { get; set; }

        public string RenterFullName { get; set; }

        public string DriverFullName { get; set; }

        public string DisplayDateReservedFor { get; set; }

        public decimal ReservationDuration { get; set; }

        public string BoatName { get; set; }

        public int NumberOfPassengers { get; set; }

        public string ReservationDetails { get; set; }

        public string Last4Digits { get; set; }

        public decimal EstimatedTotalCost { get; set; }

        public string DisplayDateReservationMade { get; set; }
    }
}
