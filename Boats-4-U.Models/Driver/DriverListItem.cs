using Boats_4_U.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.Driver
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DriverListItem
    {
        [JsonProperty]
        public int DriverId { get; set; }
        
        [JsonProperty]
        public Guid ApplicationUser { get; set; }

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

        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
    }    
}
