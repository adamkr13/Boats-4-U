using Boats_4_U.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.Driver
{
    public class DriverListItem
    {
        public int DriverId { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }        
        public List<DayOfWeek> DaysAvailable { get; set; } = new List<DayOfWeek>();
        public BoatType TypeOfBoat { get; set; }
        public int MaximumOccupants { get; set; }
        public string Location { get; set; }
        public string DriverFullName
        {
            get
            {
                var fullName = $"{DriverFirstName} {DriverLastName}";
                return fullName;
            }
        }
    }    
}
