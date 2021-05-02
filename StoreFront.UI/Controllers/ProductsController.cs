using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA;
using StoreFront.UI.Utilities;

namespace StoreFront.UI.Controllers
{
    public class ProductsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Flavor).Include(p => p.Nicotine).Include(p => p.Supplier);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.FlavorID = new SelectList(db.Flavors, "FlavorID", "Name");
            ViewBag.NicotineID = new SelectList(db.Nicotines, "NicotineID", "NicotineID");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Company");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,CategoryID,NicotineID,FlavorID,Price,InStockCt,OnOrderCt,ReorderCt,SupplierID,Image,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", product.CategoryID);
            ViewBag.FlavorID = new SelectList(db.Flavors, "FlavorID", "Name", product.FlavorID);
            ViewBag.NicotineID = new SelectList(db.Nicotines, "NicotineID", "NicotineID", product.NicotineID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Company", product.SupplierID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", product.CategoryID);
            ViewBag.FlavorID = new SelectList(db.Flavors, "FlavorID", "Name", product.FlavorID);
            ViewBag.NicotineID = new SelectList(db.Nicotines, "NicotineID", "NicotineID", product.NicotineID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Company", product.SupplierID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,CategoryID,NicotineID,FlavorID,Price,InStockCt,OnOrderCt,ReorderCt,SupplierID,Image,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", product.CategoryID);
            ViewBag.FlavorID = new SelectList(db.Flavors, "FlavorID", "Name", product.FlavorID);
            ViewBag.NicotineID = new SelectList(db.Nicotines, "NicotineID", "NicotineID", product.NicotineID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Company", product.SupplierID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
