using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderOfStars.Models;
using OrderOfStars.Controllers;

namespace OrderOfStars.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

       // private OrderOfStarsContext db = new OrderOfStarsContext();

      

    }
}
