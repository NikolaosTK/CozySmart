using CozySmart.Models;
using CozySmart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozySmart.Managers
{
    public static class AvailabilityManager
    {
        public static void AvailabilityDivision(AvailabilityFormViewModel availabilityModel, Availability availability)
        {
            using (CozySmartContext _db = new CozySmartContext())
            {
                var firstPart = new Availability()
                {
                    AvailabilityStart = availability.AvailabilityStart,
                    AvailabilityEnd = availabilityModel.OccupationStart,
                    AccommodationId = availabilityModel.AccommodationId
                };

                var secondPart = new Availability()
                {
                    AvailabilityStart = availabilityModel.OccupationEnd,
                    AvailabilityEnd = availability.AvailabilityEnd,
                    AccommodationId = availabilityModel.AccommodationId
                };


                var pastAvailability = _db.Availabilities.Find(availability.Id);
                _db.Availabilities.Remove(pastAvailability);

                _db.Availabilities.Add(firstPart);
                _db.Availabilities.Add(secondPart);
                _db.SaveChanges();
            }

        }
    }
}
