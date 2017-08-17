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
using UseIt.DAL;
using UseIt.Models;

namespace UseIt.Controllers
{
    public class ApiUITasksController : ApiController
    {
        private UseitContext db = new UseitContext();

        // GET: api/ApiUITasks
        public IQueryable<UITask> GetTasks()
        {
            return db.Tasks.Include(t => t.User);
        }

        // GET: api/ApiUITasks/5
        [ResponseType(typeof(UITask))]
        public async Task<IHttpActionResult> GetUITask(int id)
        {
            UITask uITask = await db.Tasks.FindAsync(id);
            if (uITask == null)
            {
                return NotFound();
            }

            return Ok(uITask);
        }

        // PUT: api/ApiUITasks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUITask(int id, UITask uITask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uITask.ID)
            {
                return BadRequest();
            }

            db.Entry(uITask).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UITaskExists(id))
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

        // POST: api/ApiUITasks
        [ResponseType(typeof(UITask))]
        public async Task<IHttpActionResult> PostUITask(UITask uITask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(uITask);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = uITask.ID }, uITask);
        }

        // DELETE: api/ApiUITasks/5
        [ResponseType(typeof(UITask))]
        public async Task<IHttpActionResult> DeleteUITask(int id)
        {
            UITask uITask = await db.Tasks.FindAsync(id);
            if (uITask == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(uITask);
            await db.SaveChangesAsync();

            return Ok(uITask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UITaskExists(int id)
        {
            return db.Tasks.Count(e => e.ID == id) > 0;
        }
    }
}