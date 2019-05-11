using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CozySmart.Models;
using CozySmart.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CozySmart.Controllers
{
    public class RolesController : Controller
    {


        private CozySmartContext _db;

        public RolesController()
        {
            _db = new CozySmartContext();
        }
        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddHostRole()
        {



            var userStore = new UserStore<ApplicationUser>(_db);
            var userManager = new UserManager<ApplicationUser>(userStore);


            var s = userManager.GetRoles(User.Identity.GetUserId());

            foreach (var role in s)
            {
                if (role.ToString() == "Host")
                {
                    ViewBag.message = " You have already been a host ";
                    break;
                }

                else
                {

                    userManager.AddToRole(User.Identity.GetUserId(), "Host");

                    ViewBag.message = "You are also Host";
                }

               
            }  
             

            return View();

        }


    }
}