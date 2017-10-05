using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using OrderOfStars.Models;

namespace OrderOfStars.Controllers
{
    public class RegistrationController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Регистрация";

            return View();
        }
    }
}
