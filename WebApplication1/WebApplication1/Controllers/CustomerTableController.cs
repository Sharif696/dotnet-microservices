using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerTableController : Controller
    {
        private CustomerDBEntities db = new CustomerDBEntities();

        // GET: CustomerTable
        public ActionResult Index()
        {
            return View(db.CustomerTables.ToList());
        }

        // GET: CustomerTable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return HttpNotFound();
            }
            return View(customerTable);
        }

        // GET: CustomerTable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerTable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Bill")] CustomerTable customerTable)
        {
            if (ModelState.IsValid)
            {
                db.CustomerTables.Add(customerTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerTable);
        }

        // GET: CustomerTable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return HttpNotFound();
            }
            return View(customerTable);
        }

        // POST: CustomerTable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Bill")] CustomerTable customerTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerTable);
        }

        // GET: CustomerTable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerTable customerTable = db.CustomerTables.Find(id);
            if (customerTable == null)
            {
                return HttpNotFound();
            }
            return View(customerTable);
        }

        // POST: CustomerTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerTable customerTable = db.CustomerTables.Find(id);
            db.CustomerTables.Remove(customerTable);
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
