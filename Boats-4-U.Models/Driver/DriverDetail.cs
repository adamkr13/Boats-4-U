using Boats_4_U.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.Driver
{
    public class DriverDetail
    {
        public int DriverId { get; set; }
        public Guid ApplicationUser { get; set; }
        public string DriverFullName { get; set; }
        public string Location { get; set; }
        public DaysOfWeek DaysAvailable { get; set; }
        public string BoatName { get; set; }
        public int MaximumOccupants { get; set; }
        public decimal HourlyRate { get; set; }       
    }
}
