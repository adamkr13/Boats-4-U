﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boats_4_U.Models
{
    public class RenterDetail
    {
        public int RenterId { get; set; }

        public Guid ApplicationUser { get; set; }

        public string RenterFullName { get; set; }

        public int RenterAge { get; set; }
    }
}
