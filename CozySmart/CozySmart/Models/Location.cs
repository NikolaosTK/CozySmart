using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozySmart.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string Prefecture { get; set; }

        public string City { get; set; }

        public Accommodation Accommodation { get; set; }

        public int AccommodationId { get; set; }
    }
}