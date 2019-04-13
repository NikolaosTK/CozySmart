using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartCoziness.Models
{
    public class Host
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Your first name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your last name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Your e-mail is required")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string Adress { get; set; }

        [Required]
        [Display(Name = "Date Joined")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateJoined { get; set; }

        public Property Property { get; set; }

        [Required]
        [Display(Name = "Property Name")]
        public int PropertyId { get; set; }

        //Must add profile picture
    }
}