using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace CozySmart.ViewModels
{
    public class AvailabilityForm
    {


        [Required]
        [Display(Name = "Arrival")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SearchArrival { get; set; }

        [Required]
        [Display(Name = "Departure")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SearchDeparture { get; set; }


        public int AccommodationId { get; set; }

    }
}