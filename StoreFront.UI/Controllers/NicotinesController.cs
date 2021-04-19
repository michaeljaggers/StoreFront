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
    public class NicotinesController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Nicotines
        public ActionResult Index()
        {
            return View(db.Nicotines.ToList());
        }

        // GET: Nicotines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nicotine nicotine = db.Nicotines.Find(id);
            if (nicotine == null)
            {
                return HttpNotFound();
            }
            return View(nicotine);
        }

        // GET: Nicotines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nicotines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NicotineID,StrengthMg")] Nicotine nicotine)
        {
            if (ModelState.IsValid)
            {
                db.Nicotines.Add(nicotine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nicotine);
        }

        // GET: Nicotines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nicotine nicotine = db.Nicotines.Find(id);
            if (nicotine == null)
            {
                return HttpNotFound();
            }
            return View(nicotine);
        }

        // POST: Nicotines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NicotineID,StrengthMg")] Nicotine nicotine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nicotine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nicotine);
        }

        // GET: Nicotines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nicotine nicotine = db.Nicotines.Find(id);
            if (nicotine == null)
            {
                return HttpNotFound();
            }
            return View(nicotine);
        }

        // POST: Nicotines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nicotine nicotine = db.Nicotines.Find(id);
            db.Nicotines.Remove(nicotine);
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
