using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boats_4_U.Data;
using Newtonsoft.Json;

namespace Boats_4_U.Models.Renter
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
