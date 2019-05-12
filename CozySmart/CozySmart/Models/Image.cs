using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CozySmart.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Image Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The URL of the image is required")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image Path")]
        public string ImageUrl { get; set; }

        
        //public HttpPostedFileBase ImageFile { get; set; }


        public Accommodation Accommodation { get; set; }
        
        [Required]
        [Display(Name = "Accommodation")]
        public int? AccommodationId { get; set; }

        
    }
}