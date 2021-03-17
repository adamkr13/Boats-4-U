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
    public class ReservationListItem
    {
        [JsonProperty(PropertyName = "Reservation Id")]
        public int ReservationId { get; set; }

        public Guid ApplicationUser { get; set; }

        [JsonProperty(PropertyName = "Reservation Created by User")]
        public string UserCreatedReservation { get; set; }

        [JsonProperty(PropertyName = "Logged in User")]
        public string LoggedInUser { get; set; }


        /// <summary>
        /// This creates the day of the week the reservation was made for
        /// </summary>
        [JsonProperty(PropertyName = "Date Reserved For")]
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

        /// <summary>
        /// This creates the day of the week that the reservation was made
        /// </summary>
        [JsonProperty(PropertyName = "Date Reservation Made")]
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

        public DateTimeOffset DateReservedFor { get; set; }

        public DateTimeOffset DateReservationMade { get; set; }
    }
}
