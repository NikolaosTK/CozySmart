﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CozySmart.Managers;
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

        
        //GET: Accommodations/Search/?location=XXXX&searchArrival=XXX&searchDeparture=XXX&occupancy=XXXX
        public ActionResult Search(SearchFormViewModel searchModel)
        {
            searchModel.Accommodations = _db.Accommodations.ToList();
            searchModel.Bookings = _db.Bookings.ToList();

            
            var searchResults = _db.Accommodations.ToList();
            
            
            if(searchModel.SearchLocation != null)
            {
                searchResults = searchResults
                                .Where(a => a.Location == searchModel.SearchLocation).ToList();
            }

            if (searchModel.SearchOccupancy != null)
            {
                searchResults = searchResults
                                .Where(a => a.Occupancy >= searchModel.SearchOccupancy).ToList();
            }

            if (searchModel.SearchArrival != null && searchModel.SearchDeparture != null)
            {

                //Implement availability

                foreach (var accommodation in searchResults.ToList())
                {
                    var accommodationBookings = searchModel.Bookings.Where(b => b.AccommodationId == accommodation.Id);

                    foreach (var booking in accommodationBookings)
                    {
                        if (searchModel.SearchArrival <= booking.Departure && searchModel.SearchDeparture >= booking.Arrival)
                        {
                            searchResults.Remove(accommodation);
                            break;
                        }
                    }
                }
            }

            

            Session["Dates"] = new DatesViewModel { SearchArrival = searchModel.SearchArrival,
                                                    SearchDeparture = searchModel.SearchDeparture };



            return View(searchResults);
        }

        // GET: Accommodations
        public ActionResult Index()
        {
            var accommodations = _db.Accommodations.Include(a => a.Category);
            return View(accommodations.ToList());
        }

        [HttpGet]
        public ActionResult New()
        {
            var viewModel = new AccommodationFormViewModel();

            var allAmenities = _db.Amenities.OrderBy(a => a.Description).ToList();
            var checkBoxListItems = new List<CheckBoxListItem>();

            foreach (var amenity in allAmenities)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    Id = amenity.Id,
                    Display = amenity.Description,
                    IsChecked = false
                });
            }

            viewModel.Amenities = checkBoxListItems;
            viewModel.Categories = _db.Categories.ToList();
            

            return View("AccommodationForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(AccommodationFormViewModel accommodationModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AccommodationFormViewModel
                {
                    Categories = _db.Categories.ToList()
                };

                return View("AccommodationForm", viewModel);
            }

            if(accommodationModel.Id == 0)
            {
                AccommodationManager.Add(accommodationModel);
            }
            else
            {
                AccommodationManager.Update(accommodationModel);
            }            

            return RedirectToAction("Index", "Accommodations");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var accommodation = _db.Accommodations.SingleOrDefault(a => a.Id == id);

            if (accommodation == null)
                return HttpNotFound();

            var viewModel = new AccommodationFormViewModel(accommodation);

            var allAmenities = _db.Amenities.OrderBy(a => a.Description).ToList();

            var accommodationAmenities = _db.Accommodations
                                            .Where(a => a.Id == id).Single()
                                            .Amenities.ToList();

            var checkBoxListItems = new List<CheckBoxListItem>();

            foreach (var amenity in allAmenities)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    Id = amenity.Id,
                    Display = amenity.Description,
                    IsChecked = accommodationAmenities.Where(a => a.Id == amenity.Id).Any()
                });
            }

            viewModel.Amenities = checkBoxListItems;
            viewModel.Categories = _db.Categories.ToList();

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
                Amenities = AmenitiesManager.GetForAccommodation(id),
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
