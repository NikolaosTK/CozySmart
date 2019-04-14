using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCoziness.Models
{
    public class Accommodation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Every property must have an Owner")]
        public string Owner { get; set; }

        [Required(ErrorMessage = "Title of property is required")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Title of property should be between 4 and 32 characters")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Type of property is required")]
        [DataType(DataType.Text)]
        public string Type { get; set; }

        [StringLength(100, ErrorMessage = "Description of property should be a maximum of 100 characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Multitude of rooms is required")]
        [Range(0, 20, ErrorMessage = "You should have at least 1 Room")]
        public int Rooms { get; set; }

        [Range(1, 20, ErrorMessage = "You should have at least 1 Room")]
        public int Baths { get; set; }

        [Required(ErrorMessage = "Adress of property is required")]
        public string Adress { get; set; }

        public int Rating { get; set; }

        public int Availability { get; set; }

        public Host Host { get; set; }

        [Required]
        [Display(Name = "Owner")]
        public int HostId { get; set; }

        
    }
}