﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.ReservationModels
{
    public class ReservationEdit
    {
        [Required]
        public int ReservationId { get; set; }

        [Required]
        public int NumberOfPassengers { get; set; }

        [Required]
        public DateTimeOffset DateReservedFor { get; set; }

        [Required]
        public decimal ReservationDuration { get; set; }

        public string ReservationDetails { get; set; }
    }
}
