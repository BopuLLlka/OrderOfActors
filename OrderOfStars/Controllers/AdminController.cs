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
        public ActionResult UploadPhoto()
        {
            return View();
        }
        private ApplicationContext db = new ApplicationContext();
        /// <summary>
        /// Вьюшка с админ панелью
        /// </summary>
        [Authorize(Roles ="Admin")]
        // GET: Admin
        public ActionResult AdminPanel()
        {
            return View();
        }
        /// <summary>
        /// Вьюшка с добавлением Звезды
        /// </summary>
        [Authorize(Roles = "Admin")]
        public ActionResult CreateStar()
        {
            return View();
        }
        /// <summary>
        /// Подключаем БД для работы с пользователями и ролями
        /// </summary>
        ApplicationContext context = new ApplicationContext();
        public ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        /// <summary>
        /// Возвращает вьюшку с селектами в которых 
        /// содержатся все пользователи и все роли, пока так.
        /// </summary>
        /// <returns>Передаются лист пользователей и лист ролей</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult UsersAndRoles()
        {
            
            var allUsers = context.Users.ToList();
            var allRoles = context.Roles.ToList();
            var tuple = new Tuple<List<ApplicationUser>,  List<IdentityRole>>(allUsers, allRoles);
            return View(tuple);
        }
        /// <summary>
        /// Добавляет пользователю роль и возвращает частичное представление в ajax
        /// </summary>
        /// <param name="userName">Имя пользователя из селекта</param>
        /// <param name="roleName">Имя роли из селекта</param>
        /// <returns>Возвращает текст с ошибкой или сообщающий об успехе</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddRoleToUser(string userName, string roleName)
        {
           ApplicationUser user = UserManager.FindByEmail(userName);
           try { 
                UserManager.AddToRole(user.Id, roleName);
            }
            catch
            {
                return PartialView(new ErrorModel() { ErrorText = "Роль не добавнлена" });
            }
            return PartialView(new ErrorModel() {ErrorText="Пользователю: "+userName+" добавлена роль: "+roleName});
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Orders()
        {
            return View();
        }

    }
}