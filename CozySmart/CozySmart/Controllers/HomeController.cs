using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CozySmart.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CozySmart.Controllers
{
    public class HomeController : Controller
    {

        private CozySmartContext _db;

        public HomeController()
        {
            _db = new CozySmartContext();
        }


        [AllowAnonymous]
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {

                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_db));
                ApplicationUser currentUser = UserManager.FindById(User.Identity.GetUserId());



                if (isAlsoHostUser())
                {

                    ViewBag.isAlsoHost = true;


                }
                else
                {
                    ViewBag.isAlsoHost = false;

                }

            }


            return View();
        }



        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public bool isAlsoHostUser()
        {


            var userStore = new UserStore<ApplicationUser>(_db);
            var userManager = new UserManager<ApplicationUser>(userStore);


            var roles = userManager.GetRoles(User.Identity.GetUserId());


            if (roles.Contains("Host"))
            {
                return true;

            }

            else
            {

                return false;
            }

        }



        public ActionResult FromTenantToHost()
        {
            ViewBag.isAlsoHost = true;
            ViewBag.Role = "Host";

            return View("Index");
        }


        public ActionResult FromHostToTenant()
        {

            ViewBag.isAlsoHost = true;
            ViewBag.Role = "Tenant";

            return View("Index");

        }



        public ActionResult AddHostRole()
        {



            var userStore = new UserStore<ApplicationUser>(_db);
            var userManager = new UserManager<ApplicationUser>(userStore);


            var roles = userManager.GetRoles(User.Identity.GetUserId());

            userManager.AddToRole(User.Identity.GetUserId(), "Host");

            ViewBag.isAlsoHost = true;

            return RedirectToAction("Index", "Home");
            

        }



    }
}