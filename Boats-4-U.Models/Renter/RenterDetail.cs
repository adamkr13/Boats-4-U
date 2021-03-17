using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boats_4_U.Models.Renter
{
    public class RenterDetail
    {
        [JsonProperty(PropertyName = "Renter Id")]
        public int RenterId { get; set; }

        [JsonProperty(PropertyName = "Renter Created by User")]
        public string UserCreatedRenter { get; set; }

        [JsonProperty(PropertyName = "Logged in User")]
        public string LoggedInUser { get; set; }

        [JsonProperty(PropertyName = "Renter Full Name")]
        public string RenterFullName { get; set; }

        [JsonProperty(PropertyName = "Renter Age")]
        public int RenterAge { get; set; }

        [JsonProperty(PropertyName = "Average Rating")]
        public double Rating { get; set; }

        [JsonProperty(PropertyName = "Is Renter Recommended")]
        public string Recommended { get; set; }
    }
}
