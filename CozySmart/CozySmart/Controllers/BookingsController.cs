using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CozySmart.Models;
using CozySmart.ViewModels;

namespace CozySmart.Controllers
{
    public class BookingsController : Controller
    {
        private CozySmartContext _db;

        public BookingsController()
        {
            _db = new CozySmartContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AutoBooking(int id)
        {
            var dates = Session["Dates"] as DatesViewModel;

            Booking newBooking = new Booking
            {
                AccommodationId = id,
                Arrival = dates.SearchArrival,
                Departure = dates.SearchDeparture
            };

            _db.Bookings.Add(newBooking);
            _db.SaveChanges();

            return RedirectToAction("Index", "Bookings");
        }

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = _db.Bookings.Include(b => b.Accommodation);
            return View(bookings.ToList());
        }

        public ActionResult New()
        {
            var viewModel = new BookingFormViewModel
            {
                Booking = new Booking()
                
            };

            return View("AccommodationForm", viewModel);
        }

        public ActionResult Save(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookingFormViewModel
                {
                    Booking = booking
                    
                };

                return View("AccommodationForm", viewModel);
            }

            _db.Bookings.Add(booking);           

            _db.SaveChanges();

            return RedirectToAction("Index", "Bookings");
        }



        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = _db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.AccommodationId = new SelectList(_db.Accommodations, "Id", "Title");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApplicationUserId,AccommodationId,Arrival,Departure,Occupancy,Rating")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _db.Bookings.Add(booking);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccommodationId = new SelectList(_db.Accommodations, "Id", "Title", booking.AccommodationId);
            return View(booking);
        }

       
    }
}
