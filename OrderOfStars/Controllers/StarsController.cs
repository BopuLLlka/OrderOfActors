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

        public int ReturnLength()
        {
            int length = db.Stars.Count();
            return length;
        }


        // GET: api/Stars/5
        [ResponseType(typeof(Stars))]
        public IHttpActionResult GetStars(int id)
        {
            Stars stars = db.Stars.Find(id);
            if (stars == null)
            {
                return NotFound();
            }

            return Ok(stars);
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
        public IHttpActionResult PostStars(Stars stars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stars.Add(stars);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stars.Id }, stars);
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