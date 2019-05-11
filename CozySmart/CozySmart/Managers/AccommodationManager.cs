using CozySmart.Models;
using CozySmart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozySmart.Managers
{
    public static class AccommodationManager
    {
        public static void Add(AccommodationFormViewModel accommodationModel)
        {
            using (CozySmartContext _db = new CozySmartContext())
            {
                var defaultAvailability = new Availability(accommodationModel.Id);
                var selectedAmenities = accommodationModel.Amenities.Where(a => a.IsChecked).Select(a => a.Id).ToList();

                var accommodation = new Accommodation()
                {
                    Id = accommodationModel.Id,
                    Title = accommodationModel.Title,
                    Location = accommodationModel.Location,
                    Adress = accommodationModel.Adress,
                    Thumbnail = accommodationModel.Thumbnail,
                    Description = accommodationModel.Description,
                    Occupancy = accommodationModel.Occupancy,
                    Bedrooms = accommodationModel.Bedrooms,
                    Baths = accommodationModel.Baths,
                    Price = accommodationModel.Price,
                    CategoryId = accommodationModel.CategoryId
                };

                accommodation.Availabilities.Add(defaultAvailability);

                foreach (var amenityId in selectedAmenities)
                {
                    var amenity = _db.Amenities.Find(amenityId);
                    accommodation.Amenities.Add(amenity);
                }

                _db.Accommodations.Add(accommodation);
                _db.SaveChanges();
            }
        }

        public static void Update(AccommodationFormViewModel accommodationModel)
        {
            using (CozySmartContext _db = new CozySmartContext())
            {
                var selectedAmenities = accommodationModel.Amenities.Where(a => a.IsChecked).Select(a => a.Id).ToList();

                var savingAccommodation = _db.Accommodations.Single(a => a.Id == accommodationModel.Id);

                savingAccommodation.Title = accommodationModel.Title;
                savingAccommodation.Location = accommodationModel.Location;
                savingAccommodation.Adress = accommodationModel.Adress;
                savingAccommodation.Thumbnail = accommodationModel.Thumbnail;
                savingAccommodation.Bedrooms = accommodationModel.Bedrooms;
                savingAccommodation.Baths = accommodationModel.Baths;
                savingAccommodation.Description = accommodationModel.Description;
                savingAccommodation.Price = accommodationModel.Price;
                savingAccommodation.CategoryId = accommodationModel.CategoryId;

                savingAccommodation.Amenities.Clear();

                foreach (var amenityId in selectedAmenities)
                {
                    var amenity = _db.Amenities.Find(amenityId);

                    savingAccommodation.Amenities.Add(amenity);
                }

                _db.SaveChanges();
            }
        }
    }
}