using Boats_4_U.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models.Driver
{
    public class DriverDetail
    {
        [DisplayName("Logged in user")]
        [JsonProperty(PropertyName = "Logged in User")]
        public string LoggedInUser { get; set; }
        public int DriverId { get; set; }
        public string UserCreatedDriver { get; set; }
        [Display(Name = "Driver Full Name")]
        public string DriverFullName { get; set; }
        public string Location { get; set; }
        public DaysOfWeek DaysAvailable { get; set; }
        public string BoatName { get; set; }
        public int MaximumOccupants { get; set; }
        public decimal HourlyRate { get; set; }    
        public double Rating { get; set; }
        public string Recommended { get; set; }
    }
}
