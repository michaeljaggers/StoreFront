using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA;

namespace StoreFront.UI.Controllers
{
    public class FlavorsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Flavors
        public ActionResult Index()
        {
            return View(db.Flavors.ToList());
        }

        // GET: Flavors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flavor flavor = db.Flavors.Find(id);
            if (flavor == null)
            {
                return HttpNotFound();
            }
            return View(flavor);
        }

        // GET: Flavors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flavors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlavorID,Name,Image,Description")] Flavor flavor)
        {
            if (ModelState.IsValid)
            {
                db.Flavors.Add(flavor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flavor);
        }

        // GET: Flavors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flavor flavor = db.Flavors.Find(id);
            if (flavor == null)
            {
                return HttpNotFound();
            }
            return View(flavor);
        }

        // POST: Flavors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlavorID,Name,Image,Description")] Flavor flavor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flavor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flavor);
        }

        // GET: Flavors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flavor flavor = db.Flavors.Find(id);
            if (flavor == null)
            {
                return HttpNotFound();
            }
            return View(flavor);
        }

        // POST: Flavors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flavor flavor = db.Flavors.Find(id);
            db.Flavors.Remove(flavor);
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
