using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderOfStars.Models;

namespace OrderOfStars.Controllers
{
    public class StarPageController : Controller
    {
        // GET: StarPage
        public ActionResult Index(int id)
        {

            //id = 0;
                StarsController starsController = new StarsController();
                Stars star = starsController.GetStars(id);
                ViewBag.Id = star.Id;
                ViewBag.FirstName = star.FirstName;
                ViewBag.SecondName = star.SecondName;//Заменить на LastName
                ViewBag.EMail = star.EMail;
                ViewBag.Description = star.Description;
            
            return View();
        }
    }
}