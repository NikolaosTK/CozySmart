using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCoziness.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The URL of the image is required")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}