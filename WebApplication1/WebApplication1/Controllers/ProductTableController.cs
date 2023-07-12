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
    public class ProductTableController : Controller
    {
        private ProductDBEntities db = new ProductDBEntities();

        // GET: ProductTable
        public ActionResult Index()
        {
            return View(db.ProductTable2.ToList());
        }

        // GET: ProductTable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable2 productTable2 = db.ProductTable2.Find(id);
            if (productTable2 == null)
            {
                return HttpNotFound();
            }
            return View(productTable2);
        }

        // GET: ProductTable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price")] ProductTable2 productTable2)
        {
            if (ModelState.IsValid)
            {
                db.ProductTable2.Add(productTable2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productTable2);
        }

        // GET: ProductTable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable2 productTable2 = db.ProductTable2.Find(id);
            if (productTable2 == null)
            {
                return HttpNotFound();
            }
            return View(productTable2);
        }

        // POST: ProductTable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price")] ProductTable2 productTable2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTable2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productTable2);
        }

        // GET: ProductTable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTable2 productTable2 = db.ProductTable2.Find(id);
            if (productTable2 == null)
            {
                return HttpNotFound();
            }
            return View(productTable2);
        }

        // POST: ProductTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductTable2 productTable2 = db.ProductTable2.Find(id);
            db.ProductTable2.Remove(productTable2);
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
