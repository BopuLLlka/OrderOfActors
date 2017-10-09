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
            StarsController starsController = new StarsController();
            Stars star=starsController.GetStars(id);

            //ViewBag.Id = star.Id;
            //ViewBag.FirstName = star.FirstName;
            //ViewBag.SecondName = star.SecondName;//Исправить на LastName
            //ViewBag.Description = star.Description;

            return View(star);
        }
    }
}