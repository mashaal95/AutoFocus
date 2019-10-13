﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoFocus_CodeFirst.Context;
using AutoFocus_CodeFirst.Models;
using Microsoft.AspNet.Identity;

namespace AutoFocus_CodeFirst.Controllers
{
    public class RentsController : Controller
    {
        private AutoFocusContext db = new AutoFocusContext();

        // GET: Rents
        public ActionResult Index()
        {
            var rents = db.Rents.Include(r => r.Cars).Include(r => r.Customer);
            var UserId = User.Identity.GetUserId();
            


            if (User.Identity.GetUserName() == "administrator@live.com")
            {
                return View(rents.ToList());
            }

            return View(rents.Where(s => s.CustomerId == UserId).ToList());
        }

        // GET: Rents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // GET: Rents/Create
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "CarName");
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentId,CustomerId,CarId,Rating,RatingDesc,DateOfBooking,EndOfBooking,TotalRate")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                int result = DateTime.Compare(rent.DateOfBooking, rent.EndOfBooking);

               
                db.Rents.Add(rent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Cars, "CarId", "CarName", rent.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", rent.CustomerId);
            return View(rent);
        }

        // GET: Rents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "CarName", rent.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", rent.CustomerId);
            return View(rent);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentId,CustomerId,CarId,Rating,RatingDesc,DateOfBooking,EndOfBooking,TotalRate")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "CarId", "CarName", rent.CarId);
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", rent.CustomerId);
            return View(rent);
        }

        // GET: Rents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rent rent = db.Rents.Find(id);
            db.Rents.Remove(rent);
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
