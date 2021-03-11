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

        public Guid ApplicationUser { get; set; }

        [JsonProperty]
        public string UserCreatedReservation { get; set; }

        public string RenterFirstName { get; set; }
        public string RenterLastName { get; set; }

        /// <summary>
        /// This created the Renters Full Name from the Renter's First and Last Names
        /// </summary>
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

        /// <summary>
        /// This created the Driver's Full Name from the Driver's First and Last Names
        /// </summary>
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

        /// <summary>
        /// This creates the Day of the week for the reservation
        /// </summary>
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

        /// <summary>
        /// This creates the Type of Boat from the Enum ensuring that you can only have a Boat on the Enum list
        /// </summary>
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

        /// <summary>
        /// This allows the last four numbers to be shown from the sixteen digit credit card number
        /// </summary>
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

        /// <summary>
        /// This creates the total estimated cost by multiplying the hourly rate by the reservation duration
        /// </summary>
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

        /// <summary>
        /// This creates the day that the reservation was made
        /// </summary>
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
