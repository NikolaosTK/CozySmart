using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCoziness.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public Accommodation Accomodation { get; set; }

        [Required]
        [Display(Name = "Accommodation")]
        public int AccommodationId { get; set; }

        [Display(Name = "Date Start")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [Display(Name = "Date End")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }

        
        public int Rating { get; set; }
    }
}