using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CozySmart.Models;

namespace CozySmart.ViewModels
{
    public class SearchFormViewModel
    {
        [Required]
        [Display(Name = "Location")]
        public string SearchLocation { get; set; }

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

        [Required]
        [Display(Name = "Occupancy")]
        public byte? SearchOccupancy { get; set; }

        public IEnumerable<Accommodation> Accommodations { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }
    }

    public class DatesViewModel
    {
        public DateTime SearchArrival { get; set; }

        public DateTime SearchDeparture { get; set; }

    }
}