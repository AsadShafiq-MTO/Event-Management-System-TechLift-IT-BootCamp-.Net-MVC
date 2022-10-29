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
    public class DecorationController : Controller
    {
        private EMSEntities db = new EMSEntities();

        // GET: Decoration
        public ActionResult Index()
        {
            return View(db.Decoration.ToList());
        }

        // GET: Decoration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decoration decoration = db.Decoration.Find(id);
            if (decoration == null)
            {
                return HttpNotFound();
            }
            return View(decoration);
        }

        // GET: Decoration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Decoration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Flowers,Balloon,Price")] Decoration decoration)
        {
            if (ModelState.IsValid)
            {
                db.Decoration.Add(decoration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(decoration);
        }

        // GET: Decoration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decoration decoration = db.Decoration.Find(id);
            if (decoration == null)
            {
                return HttpNotFound();
            }
            return View(decoration);
        }

        // POST: Decoration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Flowers,Balloon,Price")] Decoration decoration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(decoration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(decoration);
        }

        // GET: Decoration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decoration decoration = db.Decoration.Find(id);
            if (decoration == null)
            {
                return HttpNotFound();
            }
            return View(decoration);
        }

        // POST: Decoration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Decoration decoration = db.Decoration.Find(id);
            db.Decoration.Remove(decoration);
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
