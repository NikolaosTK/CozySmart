using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CozySmart.Models;
using ExpressiveAnnotations.Attributes;

namespace CozySmart.ViewModels
{
    public class SearchFormViewModel
    {
        [Display(Name = "Location")]
        public string SearchLocation { get; set; }

        [Display(Name = "Arrival")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        [RequiredIf("SearchDeparture != null")]
        [AssertThat("SearchArrival >= Today()")]
        public DateTime? SearchArrival { get; set; }

        [Display(Name = "Departure")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        [RequiredIf("SearchArrival != null")]
        public DateTime? SearchDeparture { get; set; }

        [Display(Name = "Number of Visitors")]
        public byte? SearchOccupancy { get; set; }

        public IEnumerable<Accommodation> Accommodations { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }
    }

    public class DatesViewModel
    {
        public DateTime? SearchArrival { get; set; }

        public DateTime? SearchDeparture { get; set; }

    }
}