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
        public ActionResult Search(SearchFormViewModel searchModel)
        {
            searchModel.Accommodations = _db.Accommodations.ToList();
            searchModel.Bookings = _db.Bookings.ToList();

            
            var locationResults = _db.Accommodations.ToList();
            
            
            if(searchModel.SearchLocation != null)
            {
                locationResults = locationResults
                                .Where(a => a.Location == searchModel.SearchLocation).ToList();
            }

            //Implementing LINQ for finding correct accommodations
            //var generalResults = mergeAboveLists.ToList();

            return View(locationResults);
        }

        // GET: Accommodations
        public ActionResult Index()
        {
            var accommodations = _db.Accommodations.Include(a => a.Category);
            return View(accommodations.ToList());
        }

        public ActionResult New()
        {
            var viewModel = new AccommodationFormViewModel
            {
                Accommodation = new Accommodation(),
                Categories = _db.Categories.ToList(),
                Amenities = _db.Amenities.Select(a => new AmenityViewModel {
                    Id = a.Id,
                    Description = a.Description
                })
            };

            return View("AccommodationForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Accommodation accommodation)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AccommodationFormViewModel
                {
                    Accommodation = accommodation,
                    Categories = _db.Categories.ToList(),
                    
                };

                return View("AccommodationForm", viewModel);
            }

            if(accommodation.Id == 0)
            {
                _db.Accommodations.Add(accommodation);
            }                
            else
            {
                var savingAccommodation = _db.Accommodations.Single(a => a.Id == accommodation.Id);
                savingAccommodation.Title = accommodation.Title;
                savingAccommodation.Location = accommodation.Location;
                savingAccommodation.Adress = accommodation.Adress;
                savingAccommodation.Thumbnail = accommodation.Thumbnail;
                savingAccommodation.Bedrooms = accommodation.Bedrooms;
                savingAccommodation.Baths = accommodation.Baths;
                savingAccommodation.Description = accommodation.Description;
                savingAccommodation.Price = accommodation.Price;
                savingAccommodation.CategoryId = accommodation.CategoryId;

            }

            _db.SaveChanges();

            return RedirectToAction("Index", "Accommodations");
        }

        public ActionResult Edit(int? id)
        {
            var accommodation = _db.Accommodations.SingleOrDefault(a => a.Id == id);

            if (accommodation == null)
                return HttpNotFound();

            var viewModel = new AccommodationFormViewModel
            {
                Accommodation = accommodation,
                Categories = _db.Categories.ToList(),
                
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

            var viewModel = new DetailsViewModel
            {
                Accommodation = _db.Accommodations.Find(id),
                Images = _db.Images.Where(i => i.AccommodationId == id)

            };
            
            if (viewModel.Accommodation == null)
            {
                return HttpNotFound();
            }
            return View("Details", viewModel);
        }
    }
}
