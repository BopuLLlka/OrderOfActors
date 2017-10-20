using Microsoft.AspNet.Identity;
using OrderOfStars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AspNetIdentityApp.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OrderOfStars.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        [Authorize(Roles ="Admin")]
        // GET: Admin
        public ActionResult AdminPanel()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateStar()
        {
            return View();
        }

        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }
        ApplicationContext context = new ApplicationContext();
        //[Authorize(Roles = "Admin")]
        public ActionResult UsersAndRoles()
        {
            
            var allUsers = context.Users.ToList();
            var allRoles = context.Roles.ToList();
            var tuple = new Tuple<List<ApplicationUser>,  List<IdentityRole>>(allUsers, allRoles);
            return View(tuple);
        }
        [HttpPost]
        public ActionResult AddRoleToUser(string userName,string roleName)
        {

            ApplicationRole role = RoleManager.FindByName(roleName);
            ApplicationUser user = context.Users.Find(userName);

            string idd = role.Id + user.Id;

            return View(idd);
        }

    }
}