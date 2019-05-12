
using Microsoft.Owin;
using Owin;
using CozySmart.Models;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;





[assembly: OwinStartupAttribute(typeof(CozySmart.Startup))]
namespace CozySmart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }



        private void createRolesandUsers()
        {
            CozySmartContext context = new CozySmartContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    


            if (!roleManager.RoleExists("Admin"))
            {


                
              

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();   
                role.Name = "Admin";   
                roleManager.Create(role);   
   
                //Here we create a Admin super user who will maintain the website                  
   
                var user = new ApplicationUser();   
                user.FirstName = "Admin";

                user.LastName = "Admin";
                user.Email = "Admin@gmail.com";   
   
                string userPWD = "Vasilis1992!";

                user.DateJoined = DateTime.Today;

                user.UserName = user.Email;

                var chkUser = UserManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }




            }

            // creating Creating Host role    
            if (!roleManager.RoleExists("Host"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Host";
                roleManager.Create(role);

            }

            // creating Creating Tenant role    
            if (!roleManager.RoleExists("Tenant"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Tenant";
                roleManager.Create(role);

            }
        }







    }
}
