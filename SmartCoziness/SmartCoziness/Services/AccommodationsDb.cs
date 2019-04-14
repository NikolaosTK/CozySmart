using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartCoziness.Models;

namespace SmartCoziness.Services
{
    /// <summary>
    /// Helper class that is used to manage Accommodations
    /// </summary>
    public class AccommodationsDb
    {
        public static IEnumerable<Accommodation> GetAll()
        {
            using (var context = new CozySmartContext())
            {
                return context.Accommodations.ToList();
            }
        }

        public static Accommodation GetById(int id)
        {
            using (var context = new CozySmartContext())
            {
                return context.Accommodations.Find(id);
            }
        }

        public static void Add(Accommodation Accommodation)
        {
            using (var context = new CozySmartContext())
            {
                context.Accommodations.Add(Accommodation);
                context.SaveChanges();
            }
        }

        public static void Update(Accommodation Accommodation)
        {
            using (var context = new CozySmartContext())
            {
                Accommodation AccommodationToUpdate = context.Accommodations.Find(Accommodation.Id);
                AccommodationToUpdate.Title = Accommodation.Title;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new CozySmartContext())
            {
                Accommodation Accommodation = context.Accommodations.Find(id);
                context.Accommodations.Remove(Accommodation);
                context.SaveChanges();
            }
        }

    }
}