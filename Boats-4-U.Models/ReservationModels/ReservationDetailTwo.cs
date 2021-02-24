using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boats_4_U.Data;
using Newtonsoft.Json;

namespace Boats_4_U.Models.ReservationModels
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ReservationDetailTwo
    {
        [JsonProperty]
        public int ReservationId { get; set; }

        [JsonProperty]
        public Guid ApplicationUser { get; set; }

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

        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }

        [JsonProperty]
        public string DriverFullName
        {
            get
            {
                var fullName = $"{DriverFirstName} {DriverLastName}";
                return fullName;
            }
        }

        public DateTimeOffset DateReservedFor { get; set; }

        [JsonProperty]
        public string DisplayDateReservedFor
        {
            get
            {
                var date = DateReservedFor;
                string fmt = "D";
                var displayDate = date.Date.ToString(fmt);
                return displayDate;
            }
        }

        [JsonProperty]
        public decimal ReservationDuration { get; set; }

        public BoatType TypeOfBoat { get; set; }

        [JsonProperty]
        public string BoatName
        {
            get
            {
                int value = (int)TypeOfBoat;
                string boatName = Enum.GetName(typeof(BoatType), value);
                return boatName;
            }
        }

        [JsonProperty]
        public int NumberOfPassengers { get; set; }

        [JsonProperty]
        public string ReservationDetails { get; set; }

        public string CreditCardNumber { get; set; }

        [JsonProperty]
        public string Last4Digits
        {
            get
            {
                var creditCardNumber = $"{CreditCardNumber}";

                return creditCardNumber.Substring(creditCardNumber.Length - 4, 4);
            }
        }

        public decimal HourlyRate { get; set; }

        [JsonProperty]
        public decimal EstimatedTotalCost
        {
            get
            {
                var estimatedTotalCost = HourlyRate * ReservationDuration;
                return estimatedTotalCost = (decimal)System.Math.Round(estimatedTotalCost,2);
            }
        }

        public DateTimeOffset DateReservationMade { get; set; }

        [JsonProperty]
        public string DisplayDateReservationMade
        {
            get
            {
                var date = DateReservationMade;
                string fmt = "D";
                var displayDate = date.Date.ToString(fmt);
                return displayDate;
            }
        }
    }
}
