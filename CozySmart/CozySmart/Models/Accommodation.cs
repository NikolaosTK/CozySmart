using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CozySmart.Models
{
    public class Accommodation
    {
        public Accommodation()
        {
            this.Amenities = new HashSet<Amenity>();
        }


        public int Id { get; set; }

        [Required(ErrorMessage="Title of property is required")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "Title of property should be between 4 and 32 characters")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The location of the accommodation is required")]
        [DataType(DataType.Text)]
        public string Location { get; set; }

        [StringLength(100, ErrorMessage = "The adress cannot exceed 100 characters")]
        public string Adress { get; set; }
       
        [Required(ErrorMessage = "Every accommodation must have a thumbnail")]
        [DataType(DataType.ImageUrl)]
        public string Thumbnail { get; set; }

        [StringLength(100, ErrorMessage="Description of property should be a maximum of 100 characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = " Occupancy is required")]
        public byte Occupancy { get; set; }
        
        [Range(0, 20, ErrorMessage="You should have at most 20 Rooms")]
        public int? Bedrooms { get; set; }

        [Range(1, 20, ErrorMessage="You should have at least 1 Room")]
        public int? Baths { get; set; }

        [Required(ErrorMessage = "The price of the accommodation is required")]
        public int? Price { get; set; }




        public Category Category { get; set; }

        [Required(ErrorMessage = "Type of property is required")]
        [Display(Name = "Accommodation Category")]
        public int CategoryId { get; set; }



        public ICollection<Image> Images { get; set; }

        public virtual ICollection<Amenity> Amenities { get; set; }





        //public int Rating { get; set; }//To implement later

        

        
    }
}