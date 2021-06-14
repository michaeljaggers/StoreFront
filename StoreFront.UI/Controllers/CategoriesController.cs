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
    public class CategoriesController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Categories/Cartidges | Shopping Page
        public ActionResult Cartridges()
        {
            List<Product> products = db.Products.Where(p => p.CategoryID == 2).ToList();
            return View(products);
        }

        // GET: Categories/Accessories | Shopping Page
        public ActionResult Accessories()
        {
            List<Product> products = db.Products.Where(p => p.CategoryID == 1).ToList();
            return View(products);
        }

        // GET: Categories | Management Page
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5 | Management Page
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create | Management Page
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create | Management
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,Name,Image,Description")] Category category, HttpPostedFileBase categoryImage)
        {
            if (ModelState.IsValid)
            {

                #region File Upload
                // Default image if none provided
                string file = "noImage.png";

                // Check if user uploaded an image
                if (categoryImage != null)
                {
                    // Preserve the file name for the image
                    file = categoryImage.FileName;

                    // Isolate the extension
                    string ext = file.Substring(file.LastIndexOf('.'));

                    // Create an array of good extensions
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //Check if the uploaded file extension is in our list of good extensions & check that the file size is <= 4MB max imposed by ASP.net
                    if (goodExts.Contains(ext.ToLower()) && categoryImage.ContentLength <= 4194304)
                    {
                        file = categoryImage.FileName;

                        #region Resize Image
                        string savePath = Server.MapPath("~/Content/imgstore/categories/");

                        Image convertedImage = Image.FromStream(categoryImage.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion
                    }
                }

                // No matter what, update the image url with the value of the file variable
                category.Image = file;

                #endregion

                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5 | Management Page
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5 | Management
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,Name,Image,Description")] Category category, HttpPostedFileBase categoryImage)
        {
            if (ModelState.IsValid)
            {

                #region File Edit
                // Default image if none provided
                string file = "noImage.png";

                // Check if user uploaded an image
                if (categoryImage != null)
                {
                    // Preserve the file name for the image
                    file = categoryImage.FileName;

                    // Isolate the extension
                    string ext = file.Substring(file.LastIndexOf('.'));

                    // Create an array of good extensions
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //Check if the uploaded file extension is in our list of good extensions & check that the file size is <= 4MB max imposed by ASP.net
                    if (goodExts.Contains(ext.ToLower()) && categoryImage.ContentLength <= 4194304)
                    {
                        // Create a new file name (using a GUID)
                        file = Guid.NewGuid() + ext;

                        #region Resize Image
                        string savePath = Server.MapPath("~/Content/imgstore/categories/");

                        Image convertedImage = Image.FromStream(categoryImage.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion

                        if (category.Image != null && category.Image != "noImage.png")
                        {
                            string path = Server.MapPath("~/Content/imgstore/categories/");
                            ImageUtility.Delete(path, category.Image);
                        }
                    }

                    // No matter what, update the image url with the value of the file variable
                    category.Image = file;
                }
                #endregion

                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5 | Management Page
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5 | Management
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);

            string path = Server.MapPath("~/Content/imgstore/categories/");
            ImageUtility.Delete(path, category.Image);

            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // AJAX DELETE Categories/AjaxDelete/5 | Management
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Admin")]
        public JsonResult AjaxDelete(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();

            string confirmMessage = string.Format($"Category \"{category.Name}\" deleted successfully!");

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
