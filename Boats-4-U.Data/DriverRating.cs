using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Data
{
    public class DriverRating
    {
        [Key]
        public int DriverRatingId { get; set; }

        [Required]
        public Guid ApplicationUser { get; set; }

        [ForeignKey(nameof(Driver))]
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        [Required, Range(0, 10)]
        public double DriverFunScore { get; set; }

        [Required, Range(0, 10)]
        public double DriverSafetyScore { get; set; }

        [Required, Range(0, 10)]
        public double DriverCleanlinessScore { get; set; }

        public double AverageOfDriverRatingScores
        {
            get
            {
                var totalScore = DriverFunScore + DriverSafetyScore + DriverCleanlinessScore;
                return Math.Round(totalScore / 3, 2);
            }
        }
    }
}
