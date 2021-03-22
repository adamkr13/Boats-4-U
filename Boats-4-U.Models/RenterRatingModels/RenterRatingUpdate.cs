using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.RenterRatingModels
{
    public class RenterRatingUpdate
    {
        [Required]
        public int RenterRatingId { get; set; }

        [Required]
        public int RenterId { get; set; }

        [Required]
        public double RenterCleanlinessScore { get; set; }

        [Required]
        public double RenterSafetyScore { get; set; }

        [Required]
        public double RenterPunctualityScore { get; set; }
    }
}
