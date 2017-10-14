using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderOfStars.Models;

namespace OrderOfStars.Controllers
{
    public class StarCardController : Controller
    {
        // GET: StarCard
        public ActionResult Index(int id)
        {
         

            return View(id);
        }
    }
}