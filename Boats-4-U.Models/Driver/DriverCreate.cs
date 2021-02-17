using Boats_4_U.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.Driver
{
    public class DriverCreate
    {
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
    }
}
