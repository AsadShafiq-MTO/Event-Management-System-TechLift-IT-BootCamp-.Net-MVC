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
    public class HallBookingController : Controller
    {
        private EMSEntities db = new EMSEntities();
        public Hall hall;

        public ActionResult HallAvalibility()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HallAvalibility([Bind(Include = "Id,HallName,TimeSlot,SeatingCapacity,MinimumBookingCapacity,Address,User_ID")] Hall hall)
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
       



        // GET: HallBooking
        public ActionResult Index()
        {
            var hallBooking = db.HallBooking.Include(h => h.AspNetUsers).Include(h => h.Services);
            return View(hallBooking.ToList());
        }

        // GET: HallBooking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallBooking hallBooking = db.HallBooking.Find(id);
            if (hallBooking == null)
            {
                return HttpNotFound();
            }
            return View(hallBooking);
        }

        // GET: HallBooking/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Service_id = new SelectList(db.Services, "Id", "Id");
            return View();
        }

        // POST: HallBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HallName,EventName,EventDate,BookingDate,TotalPayment,AddvancePayment,No0fAudience,Service_id,User_ID")] HallBooking hallBooking)
        {
            if (ModelState.IsValid)
            {
                db.HallBooking.Add(hallBooking);
                db.SaveChanges();
                return RedirectToAction("Create","Dj");
            }

            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email", hallBooking.User_ID);
            ViewBag.Service_id = new SelectList(db.Services, "Id", "Id", hallBooking.Service_id);
            return View(hallBooking);
        }

        // GET: HallBooking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallBooking hallBooking = db.HallBooking.Find(id);
            if (hallBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email", hallBooking.User_ID);
            ViewBag.Service_id = new SelectList(db.Services, "Id", "Id", hallBooking.Service_id);
            return View(hallBooking);
        }

        // POST: HallBooking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HallName,EventName,EventDate,BookingDate,TotalPayment,AddvancePayment,No0fAudience,Service_id,User_ID")] HallBooking hallBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hallBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.AspNetUsers, "Id", "Email", hallBooking.User_ID);
            ViewBag.Service_id = new SelectList(db.Services, "Id", "Id", hallBooking.Service_id);
            return View(hallBooking);
        }

        // GET: HallBooking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HallBooking hallBooking = db.HallBooking.Find(id);
            if (hallBooking == null)
            {
                return HttpNotFound();
            }
            return View(hallBooking);
        }

        // POST: HallBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HallBooking hallBooking = db.HallBooking.Find(id);
            db.HallBooking.Remove(hallBooking);
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
