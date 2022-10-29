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
    //[Authorize]
    public class HallController : Controller
    {
        private EMSEntities db = new EMSEntities();




        // GET: Hall
        public ActionResult index(string SortOrder, string SortBy)
        {
            EMSEntities dbObj = new EMSEntities();

            ViewBag.SortOrder = SortOrder;

            var data = dbObj.Hall.ToList();

            switch (SortOrder)
            {
                case "Asc":
                    {
                        data = data.OrderBy(x => x.HallName).ToList();
                        break;
                    }
                case "Desc":
                    {
                        data = data.OrderByDescending(x => x.HallName).ToList();
                        break;
                    }
                default:
                    {
                        data = data.OrderBy(x => x.HallName).ToList();
                        break;
                    }
            }

            return View(data);
        }

        [HttpPost]
        public ActionResult index(string searchTXT)
        {
            EMSEntities dbObj = new EMSEntities();

            var data = dbObj.Hall.ToList();

            if (searchTXT != null)
            {

                data = dbObj.Hall.Where(x => x.HallName.Contains(searchTXT) || x.User_ID.Contains(searchTXT)).ToList();
            }
            return View(data);
        }

        // GET: Hall/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Hall.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // GET: Hall/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Hall/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HallName,TimeSlot,SeatingCapacity,MinimumBookingCapacity,Address,User_ID")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                db.Hall.Add(hall);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email", hall.User_ID);
            return View(hall);
        }

        // GET: Hall/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Hall.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email", hall.User_ID);
            return View(hall);
        }

        // POST: Hall/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HallName,TimeSlot,SeatingCapacity,MinimumBookingCapacity,Address,User_ID")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email", hall.User_ID);
            return View(hall);
        }

        // GET: Hall/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = db.Hall.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: Hall/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hall hall = db.Hall.Find(id);
            db.Hall.Remove(hall);
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
