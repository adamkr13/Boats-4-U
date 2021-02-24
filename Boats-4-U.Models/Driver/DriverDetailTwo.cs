using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boats_4_U.Data;
using Newtonsoft.Json;

namespace Boats_4_U.Models.Driver
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DriverDetailTwo
    {
        [JsonProperty]
        public int DriverId { get; set; }

        [JsonProperty]
        public Guid ApplicationUser { get; set; }

        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }

        [JsonProperty]
        public string DriverFullName
        {
            get
            {
                var fullName = $"{DriverFirstName} {DriverLastName}";
                return fullName;
            }
        }

        [JsonProperty]
        public string Location { get; set; }

        [JsonProperty]
        public DaysOfWeek DaysAvailable { get; set; }

        public BoatType TypeOfBoat { get; set; }

        [JsonProperty]
        public string BoatName
        {
            get
            {
                int value = (int)TypeOfBoat;
                string boatName = Enum.GetName(typeof(BoatType), value);
                return boatName;
            }
        }

        [JsonProperty]
        public int MaximumOccupants { get; set; }

        [JsonProperty]
        public decimal HourlyRate { get; set; }

    }
}
