using System;
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
using Microsoft.Security.Application;

namespace AutoFocus_CodeFirst.Controllers
{
    public class CustomersController : Controller
    {
        private AutoFocusContext db = new AutoFocusContext();

        // GET: Customers
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();

            if (User.Identity.GetUserName() == "administrator@live.com")
            {
                return View(db.Customers.ToList());
            }

            return View(db.Customers.Where(s => s.CustomerId == UserId).ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "CustomerId,Name,Surname,DateOfBirth,RegistrationDate,PhoneNum")] Customer customer)
        {
            customer.CustomerId = User.Identity.GetUserId();
            customer.RegistrationDate = DateTime.Today;

            ModelState.Clear();
            TryValidateModel(customer);

            if (ModelState.IsValid)
            {
                customer.Name= Sanitizer.GetSafeHtmlFragment(customer.Name);
                customer.Surname= Sanitizer.GetSafeHtmlFragment(customer.Name);
                string conversion = customer.PhoneNum.ToString();
                conversion = Sanitizer.GetSafeHtmlFragment(conversion);
                
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "CustomerId,Name,Surname,DateOfBirth,RegistrationDate,PhoneNum")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Name = Sanitizer.GetSafeHtmlFragment(customer.Name);
                customer.Surname = Sanitizer.GetSafeHtmlFragment(customer.Name);
                string conversion = customer.PhoneNum.ToString();
                conversion = Sanitizer.GetSafeHtmlFragment(conversion);
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
