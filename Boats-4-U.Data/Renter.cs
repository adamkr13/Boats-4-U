using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Data
{
    public class Renter
    {
        [Key]
        public int RenterId { get; set; }

        [Required]
        public Guid ApplicationUser { get; set; }

        [Required]
        public string RenterFirstName { get; set; }

        [Required]
        public string RenterLastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string CreditCardNumber { get; set; }

        public virtual List<Reservation> ReservationRenter { get; set; } = new List<Reservation>();
        public virtual List<RenterRating> RenterRatings { get; set; } = new List<RenterRating>();

        public string RenterFullName
        {
            get
            {
                var fullName = $"{RenterFirstName} {RenterLastName}";
                return fullName;
            }
        }
        public string Last4Digits
        {
            get
            {
                var creditCardNumber = $"{CreditCardNumber}";

                return creditCardNumber.Substring(creditCardNumber.Length - 4, 4);
            }
        }
        public int RenterAge
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age)) age--;
                return age;
            }
        }
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
        public bool RenterIsRecommended
        {
            get
            {
                return Rating > 8;
            }
        }
        public string Recommended
        {
            get
            {
                if (RenterIsRecommended == true)
                    return $"Renter has rating of {Rating} and is recommended!";

                return "Renter has a less than stellar rating. Be sure to communicate expectations clearly before finalizing reservation.";
            }
        }
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
        public string UserCreatedRenter { get; set; }
    }
}
