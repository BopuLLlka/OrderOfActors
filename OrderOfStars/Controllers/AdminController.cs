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
using AspNetIdentityApp.Controllers;

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

        //private ApplicationRoleManager RoleManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
        //    }
        //}
        //private ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //}
        ApplicationContext context = new ApplicationContext();
        //[Authorize(Roles = "Admin")]
        public ActionResult UsersAndRoles()
        {
            
            var allUsers = context.Users.ToList();
            var allRoles = context.Roles.ToList();
            var tuple = new Tuple<List<ApplicationUser>,  List<IdentityRole>>(allUsers, allRoles);
            return View(tuple);
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [HttpPost]
        public ActionResult AddRoleToUser(string userName, string roleName)
        {
           // var roleManager = new RolesController().RoleManager;
          //  var userManager = new AccountController().UserManager;
           // ApplicationRole role = roleManager.FindByName(roleName);
            ApplicationUser user = UserManager.FindByEmail(userName);
           try { 
                UserManager.AddToRole(user.Id, roleName);
            }
            catch
            {
                return PartialView(new ErrorModel() { ErrorText = "Роль не добавнлена" });
            }

            //string sum = "ИМЯ ЮЗЕРА=" + user.Id.ToString() + "ИМЯ РОЛИ=" + role.Id.ToString();
            return PartialView(new ErrorModel() {ErrorText="Пользователю: "+userName+" добавлена роль: "+roleName});
        }

    }
}