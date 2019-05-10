using CozySmart.Models;
using CozySmart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CozySmart.Controllers
{
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

            return View();
        }


        public ActionResult AvailabilityEdit(AvailabilityForm availabilityform)
        {

            

            var availabilities = _db.Availabilities;
            var availabilities_accommodation = availabilities.Where(a => a.AccommodationId == availabilityform.AccommodationId).ToList();

            var bookings = _db.Bookings;
            var bookings_accommodation = bookings.Where(b => b.AccommodationId == availabilityform.AccommodationId).ToList();


           
            int flag = 1;
            foreach (var booking in bookings_accommodation)
            {


                if (availabilityform.SearchArrival <= booking.Departure &&  availabilityform.SearchDeparture >= booking.Arrival)

                {

                    flag = 0;
                    ViewBag.message = " ΞΑΝΑ ΔΕΣ ΤΙΣ ΚΡΑΤΗΣΕΙΣ ΣΟΥ !!!!  " ; 
                   
                }

                break;

            }

            


           if (flag == 1)
            {
               ViewBag.message = " ΟΛΑ OK !!!! ";


                if (availabilities_accommodation.Count > 0)
                {
                    foreach (var myavailability in availabilities_accommodation)
                    {



                        if (availabilityform.SearchArrival > myavailability.AvailabilityStart && availabilityform.SearchDeparture < myavailability.AvailabilityEnd)
                        {



                            var availability1 = new Availability
                            {


                                AvailabilityStart = myavailability.AvailabilityStart,
                                AvailabilityEnd = availabilityform.SearchArrival,
                                AccommodationId = availabilityform.AccommodationId



                            };

                            _db.Availabilities.Add(availability1);
                            _db.SaveChanges();

                            var availability2 = new Availability
                            {


                                AvailabilityStart = availabilityform.SearchDeparture,
                                AvailabilityEnd = myavailability.AvailabilityEnd,
                                AccommodationId = availabilityform.AccommodationId

                            };



                            _db.Availabilities.Add(availability2);
                            _db.SaveChanges();



                            Availability available = _db.Availabilities.Find(myavailability.Id);
                            _db.Availabilities.Remove(available);
                            _db.SaveChanges();




                            break;




                        }





                    }


                }

                else

                {

                    DateTime dateTime1 = new DateTime(2019, 01, 01);
                    DateTime dateTime2 = new DateTime(2019, 12, 31);


                    var availability1 = new Availability
                    {

                       
                        AvailabilityStart =  dateTime1,
                        AvailabilityEnd = availabilityform.SearchArrival,
                        AccommodationId = availabilityform.AccommodationId



                    };

                    _db.Availabilities.Add(availability1);
                    _db.SaveChanges();

                    var availability2 = new Availability
                    {


                        AvailabilityStart = availabilityform.SearchDeparture,
                        AvailabilityEnd = dateTime2,
                        AccommodationId = availabilityform.AccommodationId

                    };



                    _db.Availabilities.Add(availability2);
                    _db.SaveChanges();



                }




            }

     


            //return RedirectToAction("Index", "Home");

            return View();
          
        }


    }
}
 