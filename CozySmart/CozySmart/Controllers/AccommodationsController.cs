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
    public class AccommodationsController : Controller
    {
        private CozySmartContext _db;

        public AccommodationsController()
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

        
        //GET: Accomodations/Search/?location=XXXX&searchArrival=XXX&searchDeparture=XXX&occupancy=XXXX
        //public ActionResult Search(string location, DateTime? searchArrival, DateTime? searchDeparture, byte? occupancy)
        //{
        //    if (String.IsNullOrWhiteSpace(location)) { }
            
        //    if(!searchArrival.HasValue || !searchDeparture.HasValue) { }

        //    if (!occupancy.HasValue) { }

        //    //Implementing LINQ for finding correct accommodations
            
        //}

        // GET: Accommodations
        public ActionResult Index()
        {
            var accommodations = _db.Accommodations.Include(a => a.Category);
            return View(accommodations.ToList());
        }

        public ActionResult New()
        {
            var categories = _db.Categories.ToList();

            var viewModel = new AccommodationFormViewModel
            {
                Categories = categories
            };

            return View("AccommodationForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Accommodation accommodation)
        {
            if(accommodation.Id == 0)
            {
                _db.Accommodations.Add(accommodation);
            }                
            else
            {
                var savingAccommodation = _db.Accommodations.Single(a => a.Id == accommodation.Id);
                savingAccommodation.Title = accommodation.Title;
            }

            _db.SaveChanges();

            return RedirectToAction("Index", "Accommodations");
        }

        public ActionResult Edit(int id)
        {
            var accommodation = _db.Accommodations.SingleOrDefault(a => a.Id == id);

            if (accommodation == null)
                return HttpNotFound();

            var viewModel = new AccommodationFormViewModel
            {
                Accommodation = accommodation,
                Categories = _db.Categories.ToList()
            };

            return View("AccommodationForm", viewModel);
        }
        
        // GET: Accommodations/Details/id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accommodation accommodation = _db.Accommodations.Find(id);

            if (accommodation == null)
            {
                return HttpNotFound();
            }
            return View(accommodation);
        }
    }
}
