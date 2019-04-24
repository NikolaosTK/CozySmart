using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCoziness.Models
{
    public class Availability
    {
        public int Id;

        public DateTime StartAvailability { get; set; }

        public DateTime EndAvailability { get; set; }
    }
}