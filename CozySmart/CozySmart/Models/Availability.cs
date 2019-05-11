using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CozySmart.Models
{
    public class Availability
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "AvialabilityStart")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AvailabilityStart { get; set; }

        [Required]
        [Display(Name = "AvialabilityEnd")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AvailabilityEnd { get; set; }

        public Accommodation Accommodation { get; set; }

        [Required]
        [Display(Name = "Accommodation")]
        public int AccommodationId { get; set; }

        public Availability()
        {
        }

        public Availability(int id)
        {
            AvailabilityStart = DateTime.Today.Date;
            AvailabilityEnd = DateTime.Today.AddYears(5);
            AccommodationId = id;            
        }


    }
}