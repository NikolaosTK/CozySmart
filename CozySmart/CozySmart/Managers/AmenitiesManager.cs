using CozySmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CozySmart.Managers
{
    public static class AmenitiesManager
    {
        public static List<Amenity> GetAll()
        {
            using (CozySmartContext _db = new CozySmartContext())
            {
                return _db.Amenities.OrderBy(a => a.Description).ToList();
            }
        }

        public static Amenity GetById(int id)
        {
            using (CozySmartContext _db = new CozySmartContext())
            {
                return _db.Amenities.Where(a => a.Id == id).Single();
            }
        }

        public static List<Amenity> GetForAccommodation(int? id)
        {
            using (CozySmartContext _db = new CozySmartContext())
            {
                return _db.Accommodations.Where(a => a.Id == id).Single().Amenities.OrderBy(am => am.Description).ToList();
            }
                
        }
    }    
}