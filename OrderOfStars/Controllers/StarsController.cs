using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using OrderOfStars.Models;
using Newtonsoft.Json;
using System.Web.Http.Results;
using System.Net.Http;

namespace OrderOfStars.Controllers
{
    public class StarsController : ApiController
    {
        private OrderOfStarsBaseContext db = new OrderOfStarsBaseContext();

        // GET: api/Stars
        public JsonResult<DbSet<Stars>> GetStars()
        {

            return Json(db.Stars);
        }

        // GET: api/Stars/5
        [ResponseType(typeof(Stars))]
        public JsonResult<Stars> GetStars(int id)
        {
            //Stars star = db.Stars.Find(0); хз почему это не работает
            Stars star = db.Stars.ToList()[id];

            if (star == null)
            {
                return Json(new Stars { Id=0, FirstName="НЕНАЙДЕНААААА"});
            }
            
            return Json(star);
        }

        // PUT: api/Stars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStars(int id, Stars stars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stars.Id)
            {
                return BadRequest();
            }

            db.Entry(stars).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Stars
        [ResponseType(typeof(Stars))]
        public RedirectResult PostStars(Stars stars)
        {
            if (!ModelState.IsValid)
            {
                return Redirect(new Uri("/Admin/AdminPanel", UriKind.Relative));
            }

            db.Stars.Add(stars);
            db.SaveChanges();

            return Redirect(new Uri("/Home/Index", UriKind.Relative));
//            return CreatedAtRoute();
        }

        // DELETE: api/Stars/5
        [ResponseType(typeof(Stars))]
        public IHttpActionResult DeleteStars(int id)
        {
            Stars stars = db.Stars.Find(id);
            if (stars == null)
            {
                return NotFound();
            }

            db.Stars.Remove(stars);
            db.SaveChanges();

            return Ok(stars);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StarsExists(int id)
        {
            return db.Stars.Count(e => e.Id == id) > 0;
        }
    }
}