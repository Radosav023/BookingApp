﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public int FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public IList<RoomReservations> RoomReservationsList { get; set; }

        public IList<Comment> Comments { get; set; }

        public IList<Accommodation> Accommodation { get; set; }


    }
}