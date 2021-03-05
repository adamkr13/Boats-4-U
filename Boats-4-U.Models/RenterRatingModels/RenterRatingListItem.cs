using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boats_4_U.Data;
using Newtonsoft.Json;

namespace Boats_4_U.Models.RenterRatingModels
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RenterRatingListItem
    {
        [JsonProperty]
        public int RenterId { get; set; }

        public string RenterFirstName { get; set; }
        public string RenterLastName { get; set; }

        [JsonProperty]
        public string RenterFullName
        {
            get
            {
                var fullName = $"{RenterFirstName} {RenterLastName}";
                return fullName;
            }
        }

        public virtual List<RenterRating> RenterRatings { get; set; }

        [JsonProperty]
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
    }
}
