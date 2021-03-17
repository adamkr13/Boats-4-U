using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boats_4_U.Models.DriverRatingModels
{
    public class DriverRatingDetail
    {
        [JsonProperty(PropertyName = "Driver Rating Id")]
        public int DriverRatingId { get; set; }

        [JsonProperty(PropertyName = "Driver Rating Created by User")]
        public string UserCreatedDriverRating { get; set; }

        [JsonProperty(PropertyName = "Logged in User")]
        public string LoggedInUser { get; set; }

        public int DriverId { get; set; }

        [JsonProperty(PropertyName = "Driver Full Name")]
        public string DriverFullName { get; set; }

        [JsonProperty(PropertyName = "Fun Rating")]
        public double DriverFunScore { get; set; }

        [JsonProperty(PropertyName = "Safety Rating")]
        public double DriverSafetyScore { get; set; }

        [JsonProperty(PropertyName = "Cleanliness Rating")]
        public double DriverCleanlinessScore { get; set; }

        [JsonProperty(PropertyName = "Average Rating")]
        public double AverageOfDriverRatingScores { get; set; }
    }
}
