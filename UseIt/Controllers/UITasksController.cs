using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UseIt.DAL;
using UseIt.Models;

namespace UseIt.Controllers
{
    public class UITasksController : Controller
    {
        private UseitContext db = new UseitContext();

        // GET: UITasks
        [Authorize(Roles = "Administrator, leader, registered")]
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(u => u.User);
            return View(tasks.ToList());
        }

        // GET: UITasks/Details/5
        [Authorize(Roles = "Administrator, leader, registered")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UITask uITask = db.Tasks.Find(id);
            if (uITask == null)
            {
                return HttpNotFound();
            }
            return View(uITask);
        }

        // GET: UITasks/Create
        [Authorize(Roles = "Administrator, leader, registered")]
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "ID", "name");
            return View();
        }

        // POST: UITasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,description,alias,status,initialDate,finalDate,UserID,time,progress")] UITask uITask)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(uITask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "ID", "name", uITask.UserID);
            return View(uITask);
        }

        // GET: UITasks/Edit/5
        [Authorize(Roles = "Administrator, leader, registered")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UITask uITask = db.Tasks.Find(id);
            if (uITask == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "name", uITask.UserID);
            return View(uITask);
        }

        // POST: UITasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,description,alias,status,initialDate,finalDate,UserID,time,progress")] UITask uITask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uITask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "ID", "name", uITask.UserID);
            return View(uITask);
        }

        // GET: UITasks/Delete/5
        [Authorize(Roles = "Administrator, leader, registered")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UITask uITask = db.Tasks.Find(id);
            if (uITask == null)
            {
                return HttpNotFound();
            }
            return View(uITask);
        }

        // POST: UITasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UITask uITask = db.Tasks.Find(id);
            db.Tasks.Remove(uITask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
