using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Data
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }

        [Required]
        public string DriverFirstName { get; set; }

        [Required]
        public string DriverLastName { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public BoatType TypeOfBoat { get; set; }

        [Required]
        public DaysOfWeek DaysAvailable { get; set; }

        [Required]
        public int MaximumOccupants { get; set; }

        [Required]
        public Guid ApplicationUser { get; set; }

        public string DriverFullName
        {
            get
            {
                var fullName = $"{DriverFirstName} {DriverLastName}";
                return fullName;
            }
        }

        public string BoatName
        {
            get
            {
                int value = (int)TypeOfBoat;
                string boatName = Enum.GetName(typeof(BoatType), value);
                return boatName;
            }
        }

        public virtual List<Reservation> ReservationDriver { get; set; } = new List<Reservation>();
        public virtual List<DriverRating> DriverRatings { get; set; } = new List<DriverRating>();

        public double Rating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (var rating in DriverRatings)
                {
                    totalAverageRating += rating.AverageDriverRating;
                }

                return DriverRatings.Count > 0
                    ? Math.Round(totalAverageRating / DriverRatings.Count, 2)
                    : 0;
            }
        }

        public bool DriverIsRecommended
        {
            get
            {
                return Rating > 8;
            }
        }

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
    }

    public enum BoatType
    {
        FishingBoat = 1,
        HouseBoat,
        PontoonBoat,
        SailBoat,
        SpeedBoat
    }

    [Flags]
    [JsonConverter(typeof(FlagConverter))]
    public enum DaysOfWeek
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64,
    }
}
