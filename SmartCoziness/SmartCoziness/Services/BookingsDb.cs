using SmartCoziness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCoziness.Services
{
    public class BookingsDb
    {

        public static IEnumerable<Booking> GetAll()
        {
            using (var context = new CozySmartContext())
            {
                return context.Bookings.ToList();
            }
        }

        public static Booking GetById(int id)
        {
            using (var context = new CozySmartContext())
            {
                return context.Bookings.Find(id);
            }
        }

        public static void Add(Booking booking)
        {
            using (var context = new CozySmartContext())
            {
                context.Bookings.Add(booking);
                context.SaveChanges();
            }
        }

        public static void Update(Booking booking)
        {
            using (var context = new CozySmartContext())
            {
                Booking bookToUpdate = context.Bookings.Find(booking.Id);
                bookToUpdate.Id = booking.Id;
                bookToUpdate.AccommodationId = booking.AccommodationId;
                bookToUpdate.Arrival = booking.Arrival;
                bookToUpdate.Departure = booking.Departure;
                bookToUpdate.Rating = booking.Rating;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new CozySmartContext())
            {
                Booking booking = context.Bookings.Find(id);
                context.Bookings.Remove(booking);
                context.SaveChanges();
            }
        }
    }
}