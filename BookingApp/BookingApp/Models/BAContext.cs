﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookingApp.Models
{
    public class BAContext: IdentityDbContext<BAIdentityUser>
    {   
        public virtual DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<AccommodationType> AccommodationsTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomReservations> RoomReservations { get; set; }


        public BAContext() : base("name=DCDB")
        {          
              
        }

        public static BAContext Create()
        {
            return new BAContext();
        }
    }
}