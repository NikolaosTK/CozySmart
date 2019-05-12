using CozySmart.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CozySmart.ViewModels
{
    public class AccommodationFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title of property is required")]
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

        [StringLength(100, ErrorMessage = "Description of property should be a maximum of 100 characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = " Occupancy is required")]
        public byte? Occupancy { get; set; }

        [Range(0, 20, ErrorMessage = "You should have at most 20 Rooms")]
        public int? Bedrooms { get; set; }

        [Range(1, 20, ErrorMessage = "You should have at least 1 Room")]
        public int? Baths { get; set; }

        [Required(ErrorMessage = "The price of the accommodation is required")]
        [Display(Name = "Base price per night")]
        public int? Price { get; set; }

        [Required(ErrorMessage = "Type of property is required")]
        [Display(Name = "Accommodation Category")]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public List<CheckBoxListItem> Amenities { get; set; }


        public string PageTitle
        {
            get
            {
                return Id != 0 ? "Edit Accommodation" : "New Accommodation";
            }
        }

        public AccommodationFormViewModel()
        {
            Id = 0;

            Amenities = new List<CheckBoxListItem>();
        }

        public AccommodationFormViewModel(Accommodation accommodation)
        {
            Id = accommodation.Id;
            Title = accommodation.Title;
            Location = accommodation.Location;
            Adress = accommodation.Adress;
            Thumbnail = accommodation.Thumbnail;
            Description = accommodation.Description;
            Occupancy = accommodation.Occupancy;
            Bedrooms = accommodation.Bedrooms;
            Baths = accommodation.Baths;
            Price = accommodation.Price;
            CategoryId = accommodation.CategoryId;
        }
    }

    public class AvailabilityFormViewModel
    {
        [Required]
        [Display(Name = "Arrival")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OccupationStart { get; set; }

        [Required]
        [Display(Name = "Departure")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OccupationEnd { get; set; }


        public int AccommodationId { get; set; }
    }

    public class DetailsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title of property is required")]
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

        [StringLength(100, ErrorMessage = "Description of property should be a maximum of 100 characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = " Occupancy is required")]
        public byte? Occupancy { get; set; }

        [Range(0, 20, ErrorMessage = "You should have at most 20 Rooms")]
        public int? Bedrooms { get; set; }

        [Range(1, 20, ErrorMessage = "You should have at least 1 Room")]
        public int? Baths { get; set; }

        [Required(ErrorMessage = "The price of the accommodation is required")]
        [Display(Name = "Base price per night")]
        public int? Price { get; set; }

        [Required(ErrorMessage = "Type of property is required")]
        [Display(Name = "Accommodation Category")]
        public int CategoryId { get; set; }


        public IEnumerable<Image> Images { get; set; }

        public List<Amenity> Amenities { get; set; }

        public List<Availability> Availabilities { get; set; }

        public DetailsViewModel(Accommodation accommodation)
        {
            Id = accommodation.Id;
            Title = accommodation.Title;
            Location = accommodation.Location;
            Adress = accommodation.Adress;
            Thumbnail = accommodation.Thumbnail;
            Description = accommodation.Description;
            Occupancy = accommodation.Occupancy;
            Bedrooms = accommodation.Bedrooms;
            Baths = accommodation.Baths;
            Price = accommodation.Price;
            CategoryId = accommodation.CategoryId;
        }
    }


    public class ImageViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int AccommodationId { get; set; }
    }
}