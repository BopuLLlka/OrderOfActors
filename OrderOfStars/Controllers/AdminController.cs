using System.Web;
using System.Web.Mvc;
using OrderOfStars.Infrastructure;
using Microsoft.AspNet.Identity.Owin;

namespace OrderOfStars.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}