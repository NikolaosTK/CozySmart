using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CozySmart.Models
{
    public class Booking
    {
        public int Id { get; set; }        

        

        [Display(Name="Arrival Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Arrival { get; set; }

        [Display(Name="Departure Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Departure { get; set; }

        [Display(Name="Number of Visitors")]
        public int Occupancy { get; set; }



        public Accommodation Accomodation { get; set; }

        [Required]
        [Display(Name = "Accommodation")]
        public int AccommodationId { get; set; }






        public ApplicationUser ApplicationUser { get; set; }

        public int ApplicationUserId { get; set; }

        //public int Rating { get; set; }//Not implemented yet
    }
}