using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boats_4_U.Data;
using Newtonsoft.Json;

namespace Boats_4_U.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RenterListItem
    {
        [JsonProperty]
        public int RenterId { get; set; }

        [JsonProperty]
        public Guid ApplicationUser { get; set; }

        public string RenterFirstName { get; set; }
        public string RenterLastName { get; set; }

        /// <summary>
        /// This created the full name from the First and Last Names
        /// </summary>
        [JsonProperty]
        public string RenterFullName
        {
            get
            {
                {
                    var fullName = $"{RenterFirstName} {RenterLastName}";
                    return fullName;
                }
            }
        }

        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The created the age of the renter in years
        /// </summary>
        [JsonProperty]
        public int RenterAge
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age))
                    age--;
                return age;
            }
        }
    }
}
