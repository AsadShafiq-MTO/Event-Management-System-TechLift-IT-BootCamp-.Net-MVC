using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Event_Management_System_BootCamp.DbContext;

namespace Event_Management_System_BootCamp.Controllers
{
    public class DjController : Controller
    {
        private EMSEntities db = new EMSEntities();

        // GET: Dj
        public ActionResult Index()
        {
            return View(db.Dj.ToList());
        }

        // GET: Dj/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dj dj = db.Dj.Find(id);
            if (dj == null)
            {
                return HttpNotFound();
            }
            return View(dj);
        }

        // GET: Dj/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dj/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Speaker,SoundSystem,Price")] Dj dj)
        {
            if (ModelState.IsValid)
            {
                db.Dj.Add(dj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dj);
        }

        // GET: Dj/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dj dj = db.Dj.Find(id);
            if (dj == null)
            {
                return HttpNotFound();
            }
            return View(dj);
        }

        // POST: Dj/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Speaker,SoundSystem,Price")] Dj dj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dj);
        }

        // GET: Dj/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dj dj = db.Dj.Find(id);
            if (dj == null)
            {
                return HttpNotFound();
            }
            return View(dj);
        }

        // POST: Dj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dj dj = db.Dj.Find(id);
            db.Dj.Remove(dj);
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
