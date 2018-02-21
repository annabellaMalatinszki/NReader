using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NReaderAPI.Models;

namespace NReaderAPI.Controllers
{
    public class NewsSitesController : ApiController
    {
        private NReaderAPIContext db = new NReaderAPIContext();

        // GET: api/NewsSites
        public IQueryable<NewsSite> GetNewsSites()
        {
            return db.NewsSites;
        }

        // GET: api/NewsSites/5
        [ResponseType(typeof(NewsSite))]
        public async Task<IHttpActionResult> GetNewsSite(int id)
        {
            NewsSite newsSite = await db.NewsSites.FindAsync(id);
            if (newsSite == null)
            {
                return NotFound();
            }

            return Ok(newsSite);
        }

        // PUT: api/NewsSites/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNewsSite(int id, NewsSite newsSite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsSite.Id)
            {
                return BadRequest();
            }

            db.Entry(newsSite).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsSiteExists(id))
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

        // POST: api/NewsSites
        [ResponseType(typeof(NewsSite))]
        public async Task<IHttpActionResult> PostNewsSite(NewsSite newsSite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewsSites.Add(newsSite);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = newsSite.Id }, newsSite);
        }

        // DELETE: api/NewsSites/5
        [ResponseType(typeof(NewsSite))]
        public async Task<IHttpActionResult> DeleteNewsSite(int id)
        {
            NewsSite newsSite = await db.NewsSites.FindAsync(id);
            if (newsSite == null)
            {
                return NotFound();
            }

            db.NewsSites.Remove(newsSite);
            await db.SaveChangesAsync();

            return Ok(newsSite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsSiteExists(int id)
        {
            return db.NewsSites.Count(e => e.Id == id) > 0;
        }
    }
}