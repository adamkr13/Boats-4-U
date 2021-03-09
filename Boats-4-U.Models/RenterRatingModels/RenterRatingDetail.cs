using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models
{
    public class RenterRatingDetail
    {
        public int RenterRatingId { get; set; }

        public string Username { get; set; }

        public int RenterId { get; set; }

        public string RenterFullName { get; set; }

        public double RenterCleanlinessScore { get; set; }

        public double RenterSafetyScore { get; set; }

        public double RenterPunctualityScore { get; set; }

        public double AverageRenterRating { get; set; }
    }
}
