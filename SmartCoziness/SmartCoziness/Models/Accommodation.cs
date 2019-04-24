using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCoziness.Models
{
    public class Accommodation
    {
        public Accommodation()
        {
            this.Features = new HashSet<Feature>();
        }



        public int Id { get; set; }

        [Required(ErrorMessage="Title of property is required")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Title of property should be between 4 and 32 characters")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Adress of property is required")]
        public string Adress { get; set; }

        [StringLength(100, ErrorMessage="Description of property should be a maximum of 100 characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Type of property is required")]
        [DataType(DataType.Text)]
        public string Type { get; set; }

        [Required(ErrorMessage = " Occupancy is required")]
        public int Occupancy { get; set; }

        [Required(ErrorMessage="Multitude of rooms is required")]
        [Range(0, 20, ErrorMessage="You should have at most 20 Rooms")]
        public int Rooms { get; set; }

        [Range(1, 20, ErrorMessage="You should have at least 1 Room")]
        public int Baths { get; set; }

        public int Price { get; set; }

        





        public int Rating { get; set; }//To implement later

        public Availability Availability { get; set; }

        [Required]
        public int AvailabilityId { get; set; }

        public Host Host { get; set; }

        [Display(Name = "Owner")]
        [Required]        
        public int HostId { get; set; }

        public virtual ICollection<Feature> Features { get; set; }

        
    }
}