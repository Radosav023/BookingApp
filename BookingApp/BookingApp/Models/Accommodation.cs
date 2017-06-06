using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookingApp.Models
{
    public class Accommodation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Adress { get; set; }
        public double AvageGrade { get; set; }
        
        public double Latitude { get; set; }
        public double Longtude { get; set; }
        public string ImageUrl { get; set; }
        public bool Approved { get; set; }

        [ForeignKey("Place")]

        public int PlaceId { get; set; }
        public Region Place { get; set; }

        public IList<Room> Rooms { get; set; }

        [ForeignKey("AccommodationType")]

        public int AccommodationTypeId { get; set; }
        public AccommodationType  AccommodationType  { get; set; }

        public IList<Comment> Comments { get; set; }

        [ForeignKey("AppUser")]

        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}

