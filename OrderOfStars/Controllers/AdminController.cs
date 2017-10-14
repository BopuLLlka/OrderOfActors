using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderOfStars.Controllers
{
    public class AdminController : Controller
    {
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
}
}