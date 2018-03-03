﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCWebCodeByMadi.Models
{
    public class Venues
    {
        [Key]
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        

    }
}
