﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class AccommodationType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Accommodation> Accommodatios { get; set; }
    }
}