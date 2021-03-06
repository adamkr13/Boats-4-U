using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.DriverRatingModels
{
    public class DriverRatingDetail
    {
        public int DriverRatingId { get; set; }
        public Guid ApplicationUser { get; set; }
        public int DriverId { get; set; }
        public string DriverFullName { get; set; }
        public double DriverFunScore { get; set; }
        public double DriverSafetyScore { get; set; }
        public double DriverCleanlinessScore { get; set; }
        public double AverageOfDriverRatingScores { get; set; }
    }
}
