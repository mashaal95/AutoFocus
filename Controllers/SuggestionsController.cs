using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoFocus_CodeFirst.Context;
using AutoFocus_CodeFirst.Email;
using AutoFocus_CodeFirst.Models;

namespace AutoFocus_CodeFirst.Controllers
{
    public class SuggestionsController : Controller
    {
        private AutoFocusContext db = new AutoFocusContext();

        // GET: Suggestions
        public ActionResult Index()
        {
            var suggestions = db.Suggestions.Include(s => s.Customers);
            return View(suggestions.ToList());
        }

        // GET: Suggestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestion suggestion = db.Suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View(suggestion);
        }

        // GET: Suggestions/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            return View();
        }

        // POST: Suggestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,FromName,FromEmail,EmailMessage")] Suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                EmailFunctionality es = new EmailFunctionality();
                es.Send(suggestion.FromEmail, suggestion.FromName, suggestion.EmailMessage);
                db.Suggestions.Add(suggestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", suggestion.CustomerId);
            return View(suggestion);
        }

        // GET: Suggestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestion suggestion = db.Suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", suggestion.CustomerId);
            return View(suggestion);
        }

        // POST: Suggestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,FromName,FromEmail,EmailMessage")] Suggestion suggestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suggestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", suggestion.CustomerId);
            return View(suggestion);
        }

        // GET: Suggestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suggestion suggestion = db.Suggestions.Find(id);
            if (suggestion == null)
            {
                return HttpNotFound();
            }
            return View(suggestion);
        }

        // POST: Suggestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suggestion suggestion = db.Suggestions.Find(id);
            db.Suggestions.Remove(suggestion);
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

   
