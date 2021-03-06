﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [JsonProperty(PropertyName = "Logged in User")]
        public string LoggedInUser { get; set; }

        [JsonProperty(PropertyName = "Driver Id")]
        public int DriverId { get; set; }

        public Guid ApplicationUser { get; set; }

        [JsonProperty(PropertyName = "Driver Created by User")]
        public string UserCreatedDriver { get; set; }
       

        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }

        /// <summary>
        /// This created the Driver's Full Name from the Drivers First and Last Names
        /// </summary>
        [JsonProperty(PropertyName = "Driver Full Name")]
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

        [JsonProperty(PropertyName = "Days Available")]
        public DaysOfWeek DaysAvailable { get; set; }

        public BoatType TypeOfBoat { get; set; }

        /// <summary>
        /// This created the Type of Boat from the Enum ensuring you can only have a type in the Enum list
        /// </summary>
        [JsonProperty(PropertyName = "Type of Boat")]
        public string BoatName
        {
            get
            {
                int value = (int)TypeOfBoat;
                string boatName = Enum.GetName(typeof(BoatType), value);
                return boatName;
            }
        }

        [JsonProperty(PropertyName = "Maximum Occupancy")]
        public int MaximumOccupants { get; set; }

        [JsonProperty(PropertyName = "Hourly Rate")]
        public decimal HourlyRate { get; set; }

        public virtual List<DriverRating> DriverRatings { get; set; }

        [JsonProperty(PropertyName = "Fun Rating")]
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

        [JsonProperty(PropertyName = "Safety Rating")]
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

        [JsonProperty(PropertyName = "Cleanliness Rating")]
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

        [JsonProperty(PropertyName = "Average Rating")]
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

        [JsonProperty(PropertyName = "Is Driver Recommended")]
        public bool DriverIsRecommended
        {
            get
            {
                return Rating > 8;
            }
        }

        [JsonProperty(PropertyName = "Recommendation for Driver")]
        public string Recommended
        {
            get
            {
                if (DriverIsRecommended == true)
                    return $"Driver has rating of {Rating} and is highly recommended!";

                return "Driver has a less than stellar rating. Be sure to communicate expectations clearly before finalizing reservation.";
            }
        }
    }
}
