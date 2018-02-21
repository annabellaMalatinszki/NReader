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

namespace NReader.Controllers
{
    public class NewsItemsController : ApiController
    {
        private NReaderAPIContext db = new NReaderAPIContext();

        // GET: api/NewsItems
        public IQueryable<NewsItemDTO> GetNewsItems()
        {
            var newsItems = from n in db.NewsItems
                            select new NewsItemDTO()
                            {
                                Id = n.Id,
                                Title = n.Title,
                                Description = n.Description,
                                NewsSiteName = n.NewsSite.Name
                            };
            return newsItems;
        }

        // GET: api/NewsItems/5
        [ResponseType(typeof(NewsItemDetailDTO))]
        public async Task<IHttpActionResult> GetNewsItem(int id)
        {
            var newsItem = await db.NewsItems.Include(n => n.NewsSite).Select(n =>
                new NewsItemDetailDTO()
                {
                    Id = n.Id,
                    Title = n.Title,
                    Description = n.Description,
                    PublicationDate = n.PublicationDate,
                    ArticleUrl = n.ArticleUrl,
                    PicUrl = n.PicUrl,
                    NewsSiteName = n.NewsSite.Name
                }).SingleOrDefaultAsync(n => n.Id == id);

            if (newsItem == null)
            {
                return NotFound();
            }

            return Ok(newsItem);
        }

        // PUT: api/NewsItems/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNewsItem(int id, NewsItem newsItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsItem.Id)
            {
                return BadRequest();
            }

            db.Entry(newsItem).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsItemExists(id))
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

        // POST: api/NewsItems
        [ResponseType(typeof(NewsItem))]
        public async Task<IHttpActionResult> PostNewsItem(NewsItem newsItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewsItems.Add(newsItem);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = newsItem.Id }, newsItem);
        }

        // DELETE: api/NewsItems/5
        [ResponseType(typeof(NewsItem))]
        public async Task<IHttpActionResult> DeleteNewsItem(int id)
        {
            NewsItem newsItem = await db.NewsItems.FindAsync(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            db.NewsItems.Remove(newsItem);
            await db.SaveChangesAsync();

            return Ok(newsItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsItemExists(int id)
        {
            return db.NewsItems.Count(e => e.Id == id) > 0;
        }
    }
}