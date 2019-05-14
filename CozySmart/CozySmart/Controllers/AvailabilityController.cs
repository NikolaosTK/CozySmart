using CozySmart.Managers;
using CozySmart.Models;
using CozySmart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CozySmart.Controllers
{


    [Authorize(Roles = "Host")]
    public class AvailabilityController : Controller
    {
        private CozySmartContext _db;

        public AvailabilityController()
        {
            _db = new CozySmartContext();
        }

        // GET: Availability
        public ActionResult Index()
        {
            var availability = _db.Availabilities.ToList();
            return View(availability);
        }

        public ActionResult New(int id)
        {
            var viewModel = new AvailabilityFormViewModel();

            viewModel.AccommodationId = id;

            return View("AvailabilityForm", viewModel);
        }


        [HttpPost]
        public ActionResult Add(AvailabilityFormViewModel availabilityModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AvailabilityForm", availabilityModel);
            }

            var accommodationAvailability = _db.Availabilities.Where(a => a.AccommodationId == availabilityModel.AccommodationId).ToList();

            var accommodationBookings = _db.Bookings.Where(b => b.AccommodationId == availabilityModel.AccommodationId).ToList();


            foreach (var booking in accommodationBookings)
            {
                if (availabilityModel.OccupationStart <= booking.Departure && availabilityModel.OccupationEnd >= booking.Arrival)
                {
                    return View();
                }
            }

            foreach (var availability in accommodationAvailability)
            {
                if (availabilityModel.OccupationStart > availability.AvailabilityStart && availabilityModel.OccupationEnd < availability.AvailabilityEnd)
                {
                    AvailabilityManager.AvailabilityDivision(availabilityModel, availability);
                  
                    break;
                }
                else
                {
                    return View();
                }
            }
            
            return RedirectToAction("Index", "Availability");
        }
    }
}
