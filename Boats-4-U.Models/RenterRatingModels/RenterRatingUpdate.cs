using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.RenterRatingModels
{
    public class RenterRatingUpdate
    {
        public int RenterRatingId { get; set; }
        public int RenterId { get; set; }
        public double RenterCleanlinessScore { get; set; }
        public double RenterSafetyScore { get; set; }
        public double RenterPunctualityScore { get; set; }
    }
}
