using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boats_4_U.Data;
using Newtonsoft.Json;

namespace Boats_4_U.Models.Renter
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RenterListItem
    {
        [JsonProperty(PropertyName = "Renter Id")]
        public int RenterId { get; set; }

        public Guid ApplicationUser { get; set; }

        [JsonProperty(PropertyName = "Renter Created by User")]
        public string UserCreatedRenter { get; set; }

        [JsonProperty(PropertyName = "Logged in User")]
        public string LoggedInUser { get; set; }


        public string RenterFirstName { get; set; }
        public string RenterLastName { get; set; }

        /// <summary>
        /// This created the full name from the First and Last Names
        /// </summary>
        [JsonProperty(PropertyName = "Renter Full Name")]
        public string RenterFullName
        {
            get
            {
                {
                    var fullName = $"{RenterFirstName} {RenterLastName}";
                    return fullName;
                }
            }
        }

        [JsonProperty(PropertyName = "Renter Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The created the age of the renter in years
        /// </summary>
        [JsonProperty(PropertyName = "Renter Age")]
        public int RenterAge
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age))
                    age--;
                return age;
            }
        }

        public virtual List<RenterRating> RenterRatings { get; set; } = new List<RenterRating>();

        [JsonProperty(PropertyName = "Average Rating")]
        public double Rating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (var rating in RenterRatings)
                {
                    totalAverageRating += rating.AverageRenterRating;
                }

                return RenterRatings.Count > 0
                    ? Math.Round(totalAverageRating / RenterRatings.Count, 2)
                    : 0;
            }
        }

        [JsonProperty(PropertyName = "Cleanliness Rating")]
        public double CleanlinessRating
        {
            get
            {
                double averageCleanlinessRating = 0;

                foreach (RenterRating renterRating in RenterRatings)
                {
                    averageCleanlinessRating += renterRating.RenterCleanlinessScore;
                }

                return RenterRatings.Count > 0
                    ? Math.Round(averageCleanlinessRating / RenterRatings.Count, 2)
                    : 0;
            }
        }

        [JsonProperty(PropertyName = "Safety Rating")]
        public double SafetyRating
        {
            get
            {
                double averageSafetyRating = 0;

                foreach (RenterRating renterRating in RenterRatings)
                {
                    averageSafetyRating += renterRating.RenterSafetyScore;
                }

                return RenterRatings.Count > 0
                    ? Math.Round(averageSafetyRating / RenterRatings.Count, 2)
                    : 0;
            }
        }

        [JsonProperty(PropertyName = "Punctuality Rating")]
        public double PunctualityRating
        {
            get
            {
                double averagePunctualityRating = 0;

                foreach (var renterRating in RenterRatings)
                {
                    averagePunctualityRating += renterRating.RenterPunctualityScore;
                }

                return RenterRatings.Count > 0
                    ? Math.Round(averagePunctualityRating / RenterRatings.Count, 2)
                    : 0;
            }
        }
    }
}
