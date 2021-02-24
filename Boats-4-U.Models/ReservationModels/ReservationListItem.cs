using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Boats_4_U.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ReservationListItem
    {
        [JsonProperty]
        public int ReservationId { get; set; }

        [JsonProperty]
        public Guid User { get; set; }

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
