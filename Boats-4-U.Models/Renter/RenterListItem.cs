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

        [JsonProperty]
        public int RenterAge { get; set; }

        [JsonProperty]
        public string Last4Digits
        {
            get
            {
                var creditCardNumber = $"{CreditCardNumber}";

                return creditCardNumber.Substring(creditCardNumber.Length - 4, 4);
            }
        }

        public string RenterFirstName { get; set; }

        public string RenterLastName { get; set; }

        public string CreditCardNumber { get; set; }

        
    }
}
