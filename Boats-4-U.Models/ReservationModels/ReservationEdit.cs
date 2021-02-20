using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models
{
    public class ReservationEdit
    {
        public int ReservationId { get; set; }

        public int NumberOfPassengers { get; set; }

        public DateTimeOffset DateReservedFor { get; set; }

        public decimal ReservationDuration { get; set; }

        public string ReservationDetails { get; set; }
    }
}
