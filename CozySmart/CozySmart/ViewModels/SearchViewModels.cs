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
        [DisplayFormat(DataFormatString = "{0: dd-MMM-yyyy}")]
        public DateTime SearchArrival { get; set; }

        [Required]
        [Display(Name = "Departure")]
        [DisplayFormat(DataFormatString = "{0: dd-MMM-yyyy}")]
        public DateTime SearchDeparture { get; set; }

        [Required]
        [Display(Name = "Occupancy")]
        public byte SearchOccupancy { get; set; }

        public IEnumerable<Accommodation> Accommodations { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }
    }

    public class SearchResultViewModel
    {        
       public IEnumerable<Accommodation> AccommodationResults { get; set; }
    }
}