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

        public virtual List<DriverRating> DriverRatings { get; set; }

        public double FunRating
        {
            get
            {
                double averageFunRating = 0;

                foreach (DriverRating driverRating in DriverRatings)
                {
                    averageFunRating += driverRating.DriverFunScore;
                }

                return DriverRatings.Count > 0
                    ? Math.Round(averageFunRating / DriverRatings.Count, 2)
                    : 0;
            }
        }
        public double SafetyRating
        {
            get
            {
                double averageSafetyRating = 0;

                foreach (DriverRating driverRating in DriverRatings)
                {
                    averageSafetyRating += driverRating.DriverSafetyScore;
                }

                return DriverRatings.Count > 0
                    ? Math.Round(averageSafetyRating / DriverRatings.Count, 2)
                    : 0;
            }
        }
        public double CleanlinessRating
        {
            get
            {
                double averageCleanlinessRating = 0;

                foreach (var driverRating in DriverRatings)
                {
                    averageCleanlinessRating += driverRating.DriverCleanlinessScore;
                }

                return DriverRatings.Count > 0
                    ? Math.Round(averageCleanlinessRating / DriverRatings.Count, 2)
                    : 0;
            }
        }

        [JsonProperty]
        public double Rating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (var rating in DriverRatings)
                {
                    totalAverageRating += rating.AverageOfDriverRatingScores;
                }

                return DriverRatings.Count > 0
                    ? Math.Round(totalAverageRating / DriverRatings.Count, 2)
                    : 0;
            }
        }

        [JsonProperty]
        public bool DriverIsRecommended
        {
            get
            {
                return Rating > 8;
            }
        }
    }
}
