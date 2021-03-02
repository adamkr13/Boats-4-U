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

        public virtual List<Reservation> ReservationRenter { get; set; } = new List<Reservation>();
        public virtual List<RenterRating> RenterRatings { get; set; } = new List<RenterRating>();

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

        public bool IsRecommended
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

                foreach (RenterRating renterRating in RenterRatings)
                {
                    averageFunRating += renterRating.RenterFun;
                }

                return RenterRatings.Count > 0
                    ? Math.Round(averageFunRating / RenterRatings.Count, 2)
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
                    averageSafetyRating += renterRating.RenterSafety;
                }

                return RenterRatings.Count > 0
                    ? Math.Round(averageSafetyRating / RenterRatings.Count, 2)
                    : 0;
            }
        }

        public double CleanlinessRating
        {
            get
            {
                double averageCleanlinessRating = 0;

                foreach (var renterRating in RenterRatings)
                {
                    averageCleanlinessRating += renterRating.RenterCleanliness;
                }

                return RenterRatings.Count > 0
                    ? Math.Round(averageCleanlinessRating / RenterRatings.Count, 2)
                    : 0;
            }
        }
    }
}
