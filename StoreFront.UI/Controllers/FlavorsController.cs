
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StoreFront.DATA;
using StoreFront.UI.Utilities;

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
        public ActionResult Create([Bind(Include = "FlavorID,Name,Image,Description")] Flavor flavor, HttpPostedFileBase flavorImage)
        {
            if (ModelState.IsValid)
            {

                #region File Upload
                // Default image if none provided
                string file = "noImage.png";

                // Check if user uploaded an image
                if (flavorImage != null)
                {
                    // Preserve the file name for the image
                    file = flavorImage.FileName;

                    // Isolate the extension
                    string ext = file.Substring(file.LastIndexOf('.'));

                    // Create an array of good extensions
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //Check if the uploaded file extension is in our list of good extensions & check that the file size is <= 4MB max imposed by ASP.net
                    if (goodExts.Contains(ext.ToLower()) && flavorImage.ContentLength <= 4194304)
                    {
                        // Create a new file name (using a GUID)
                        file = Guid.NewGuid() + ext;

                        #region Resize Image
                        string savePath = Server.MapPath("~/Content/imgstore/flavors/");

                        Image convertedImage = Image.FromStream(flavorImage.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion
                    }
                }

                // No matter what, update the image url with the value of the file variable
                flavor.Image = file;

                #endregion

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
        public ActionResult Edit([Bind(Include = "FlavorID,Name,Image,Description")] Flavor flavor, HttpPostedFileBase flavorImage)
        {
            if (ModelState.IsValid)
            {

                #region File Edit
                // Default image if none provided
                string file = "noImage.png";

                // Check if user uploaded an image
                if (flavorImage != null)
                {
                    // Preserve the file name for the image
                    file = flavorImage.FileName;

                    // Isolate the extension
                    string ext = file.Substring(file.LastIndexOf('.'));

                    // Create an array of good extensions
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //Check if the uploaded file extension is in our list of good extensions & check that the file size is <= 4MB max imposed by ASP.net
                    if (goodExts.Contains(ext.ToLower()) && flavorImage.ContentLength <= 4194304)
                    {
                        // Create a new file name (using a GUID)
                        file = Guid.NewGuid() + ext;

                        #region Resize Image
                        string savePath = Server.MapPath("~/Content/imgstore/flavors/");

                        Image convertedImage = Image.FromStream(flavorImage.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion

                        if (flavor.Image != null && flavor.Image != "noImage.png")
                        {
                            string path = Server.MapPath("~/Content/imgstore/flavors/");
                            ImageUtility.Delete(path, flavor.Image);
                        }
                    }

                    // No matter what, update the image url with the value of the file variable
                    flavor.Image = file;
                }
                #endregion

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

            string path = Server.MapPath("~/Content/imgstore/flavors/");
            ImageUtility.Delete(path, flavor.Image);
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
