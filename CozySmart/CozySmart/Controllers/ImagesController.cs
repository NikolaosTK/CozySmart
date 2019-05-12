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

    [Authorize]
    public class ImagesController : Controller
    {
        private CozySmartContext db = new CozySmartContext();

        // GET: Images
        public ActionResult Index()
        {
            var images = db.Images.Include(i => i.Accommodation);
            return View(images.ToList());
        }

        // GET: Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        public ActionResult New(int id)
        {
            var viewModel = new ImageViewModel();
            viewModel.AccommodationId = id;

            return View("New", viewModel);
        }

        public ActionResult Add(ImageViewModel imageModel)
        {
            var accommodation = db.Accommodations.Find(imageModel.AccommodationId);

            var newImage = new Image()
            {
                Id = imageModel.Id,
                Title = imageModel.Title,
                ImageUrl = imageModel.ImageUrl
            };

            accommodation.Images.Add(newImage);
            db.SaveChanges();

            return RedirectToAction("Details","Accommodations", new { id = imageModel.AccommodationId});
        }

        

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ImageUrl,AccommodationId")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccommodationId = new SelectList(db.Accommodations, "Id", "Title", image.AccommodationId);
            return View(image);
        }

        

        // GET: Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
