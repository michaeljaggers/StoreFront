﻿using System;
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
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Orders/Index | Management
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Shipper);
            return View(orders.ToList());
        }

        // GET: Orders/Details/5 | Management
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create | Management
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name");
            return View();
        }

        // POST: Orders/Create | Management
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerID,OrderDate,ShipDate,ShipperID,Freight,ShipAddress,ShipCity,ShipState,ShipZip,ShipCountry")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", order.CustomerID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", order.ShipperID);
            return View(order);
        }

        // GET: Orders/Edit/5 | Management
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", order.CustomerID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", order.ShipperID);
            return View(order);
        }

        // POST: Orders/Edit/5 | Management
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,OrderDate,ShipDate,ShipperID,Freight,ShipAddress,ShipCity,ShipState,ShipZip,ShipCountry")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", order.CustomerID);
            ViewBag.ShipperID = new SelectList(db.Shippers, "ShipperID", "Name", order.ShipperID);
            return View(order);
        }

        // GET: Orders/Delete/5 | Management
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5 | Management
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // AJAX DELETE Orders/AjaxDelete/5 | Management
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AjaxDelete(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();

            string confirmMessage = string.Format($"Order ID: {order.OrderID} deleted successfully!");

            return Json(new { id = id, message = confirmMessage });
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
