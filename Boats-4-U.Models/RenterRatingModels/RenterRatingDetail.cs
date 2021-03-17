using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boats_4_U.Models
{
    public class RenterRatingDetail
    {
        [JsonProperty(PropertyName = "Renter Rating Id")]
        public int RenterRatingId { get; set; }

        [JsonProperty(PropertyName = "Renter Rating Created by User")]
        public string UserCreatedRenterRating { get; set; }

        [JsonProperty(PropertyName = "Logged in User")]
        public string LoggedInUser { get; set; }

        [JsonProperty(PropertyName = "Renter Id")]
        public int RenterId { get; set; }

        [JsonProperty(PropertyName = "Renter Full Name")]
        public string RenterFullName { get; set; }

        [JsonProperty(PropertyName = "Cleanliness Rating")]
        public double RenterCleanlinessScore { get; set; }

        [JsonProperty(PropertyName = "Safety Rating")]
        public double RenterSafetyScore { get; set; }

        [JsonProperty(PropertyName = "Punctuality Rating")]
        public double RenterPunctualityScore { get; set; }

        [JsonProperty(PropertyName = "Average Rating")]
        public double AverageRenterRating { get; set; }
    }
}
