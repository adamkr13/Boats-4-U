﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Data
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        [Required]
        public string DriverFirstName { get; set; }

        [Required]
        public string DriverLastName { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public BoatType TypeOfBoat { get; set; }

        [Required]
        public List<DayOfWeek> DaysAvailable { get; set; } = new List<DayOfWeek>();

        [Required]
        public int MaximumOccupants { get; set; }

        [Required]
        public Guid User { get; set; }

        public string DriverFullName
        {
            get
            {
                var fullName = $"{DriverFirstName} {DriverLastName}";
                return fullName;
            }
        }

        public string BoatName
        {
            get
            {
                int value = (int)TypeOfBoat;
                string boatName = Enum.GetName(typeof(BoatType), value);
                return boatName;
            }
        }

        public virtual List<Reservation> ReservationDriver { get; set; } = new List<Reservation>();
    }

    public enum BoatType
    {
        FishingBoat = 1,
        HouseBoat,
        PontoonBoat,
        SailBoat,
        SpeedBoat
    }
}
