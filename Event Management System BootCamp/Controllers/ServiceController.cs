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
    public class ServiceController : Controller
    {
        private EMSEntities db = new EMSEntities();

        // GET: Service
        public ActionResult Index()
        {
            var services = db.Services.Include(s => s.Decoration).Include(s => s.Dj).Include(s => s.Menu);
            return View(services.ToList());
        }

        // GET: Service/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // GET: Service/Create
        public ActionResult Create()
        {
            ViewBag.Decoration_id = new SelectList(db.Decoration, "Id", "Flowers");
            ViewBag.Dj_id = new SelectList(db.Dj, "Id", "Speaker");
            ViewBag.Menu_id = new SelectList(db.Menu, "Id", "MenuName");
            return View();
        }

        // POST: Service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Dj_id,Menu_id,Decoration_id")] Services services)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Decoration_id = new SelectList(db.Decoration, "Id", "Flowers", services.Decoration_id);
            ViewBag.Dj_id = new SelectList(db.Dj, "Id", "Speaker", services.Dj_id);
            ViewBag.Menu_id = new SelectList(db.Menu, "Id", "MenuName", services.Menu_id);
            return View(services);
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            ViewBag.Decoration_id = new SelectList(db.Decoration, "Id", "Flowers", services.Decoration_id);
            ViewBag.Dj_id = new SelectList(db.Dj, "Id", "Speaker", services.Dj_id);
            ViewBag.Menu_id = new SelectList(db.Menu, "Id", "MenuName", services.Menu_id);
            return View(services);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Dj_id,Menu_id,Decoration_id")] Services services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(services).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Decoration_id = new SelectList(db.Decoration, "Id", "Flowers", services.Decoration_id);
            ViewBag.Dj_id = new SelectList(db.Dj, "Id", "Speaker", services.Dj_id);
            ViewBag.Menu_id = new SelectList(db.Menu, "Id", "MenuName", services.Menu_id);
            return View(services);
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = db.Services.Find(id);
            if (services == null)
            {
                return HttpNotFound();
            }
            return View(services);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Services services = db.Services.Find(id);
            db.Services.Remove(services);
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
