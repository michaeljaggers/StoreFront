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
using StoreFront.UI.Models;

namespace StoreFront.UI.Controllers
{
    
    public class ProductsController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        // GET: Products/Index | Management
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Flavor).Include(p => p.Nicotine).Include(p => p.Supplier);
            return View(products.ToList());
        }

        // GET Products/Detail/1 | Shopping
        [HttpGet]
        public ActionResult Detail(int? id)
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

        // GET: Products/Details/5 | Management
        [Authorize(Roles = "Admin")]
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

        // GET: Modal Partial | Shopping
        public ActionResult ModalPartial(int? id)
        {
            Product product = db.Products.Find(id);
            return PartialView("ModalPartial", product);
        }

        // GET: Featured Products Partial | Shopping
        public ActionResult FeaturedProducts()
        {
            List<Product> products = db.Products.Where(p => p.IsFeatured == true).ToList();
            return PartialView("FeaturedProducts", products);
        }

        // GET: Products/Create | Management
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.FlavorID = new SelectList(db.Flavors, "FlavorID", "Name");
            ViewBag.NicotineID = new SelectList(db.Nicotines, "NicotineID", "StrengthMg");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Company");
            return View();
        }

        // POST: Products/Create | Management
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,CategoryID,NicotineID,FlavorID,Price,InStockCt,OnOrderCt,ReorderCt,SupplierID,Image,Description,IsFeatured")] Product product, HttpPostedFileBase productImage)
        {
            if (ModelState.IsValid)
            {

                #region File Upload
                // Default image if none provided
                string file = "noImage.png";

                // Check if user uploaded an image
                if (productImage != null)
                {
                    // Preserve the file name for the image
                    file = productImage.FileName;

                    // Isolate the extension
                    string ext = file.Substring(file.LastIndexOf('.'));

                    // Create an array of good extensions
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //Check if the uploaded file extension is in our list of good extensions & check that the file size is <= 4MB max imposed by ASP.net
                    if (goodExts.Contains(ext.ToLower()) && productImage.ContentLength <= 4194304)
                    {
                        // Create a new file name (using a GUID)
                        file = Guid.NewGuid() + ext;

                        #region Resize Image
                        string savePath = Server.MapPath("~/Content/imgstore/products/");

                        Image convertedImage = Image.FromStream(productImage.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion
                    }
                }

                // No matter what, update the image url with the value of the file variable
                product.Image = file;

                #endregion

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", product.CategoryID);
            ViewBag.FlavorID = new SelectList(db.Flavors, "FlavorID", "Name", product.FlavorID);
            ViewBag.NicotineID = new SelectList(db.Nicotines, "NicotineID", "StrengthMg", product.NicotineID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Company", product.SupplierID);
            return View(product);
        }

        // GET: Products/Edit/5 | Management
        [Authorize(Roles = "Admin")]
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
            ViewBag.NicotineID = new SelectList(db.Nicotines, "NicotineID", "StrengthMg", product.NicotineID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Company", product.SupplierID);
            return View(product);
        }


        // POST: Products/Edit/5 | Management
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,CategoryID,NicotineID,FlavorID,Price,InStockCt,OnOrderCt,ReorderCt,SupplierID,Image,Description,IsFeatured")] Product product, HttpPostedFileBase productImage)
        {
            if (ModelState.IsValid)
            {

                #region File Edit
                // Default image if none provided
                string file = "noImage.png";

                // Check if user uploaded an image
                if (productImage != null)
                {
                    // Preserve the file name for the image
                    file = productImage.FileName;

                    // Isolate the extension
                    string ext = file.Substring(file.LastIndexOf('.'));

                    // Create an array of good extensions
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    //Check if the uploaded file extension is in our list of good extensions & check that the file size is <= 4MB max imposed by ASP.net
                    if (goodExts.Contains(ext.ToLower()) && productImage.ContentLength <= 4194304)
                    {

                        file = productImage.FileName;

                        #region Resize Image
                        string savePath = Server.MapPath("~/Content/imgstore/products/");

                        Image convertedImage = Image.FromStream(productImage.InputStream);

                        int maxImageSize = 500;

                        int maxThumbSize = 100;

                        ImageUtility.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                        #endregion

                        if (product.Image != null && product.Image != "noImage.png")
                        {
                            string path = Server.MapPath("~/Content/imgstore/products/");
                            ImageUtility.Delete(path, product.Image);
                        }
                    }

                    // No matter what, update the image url with the value of the file variable
                    product.Image = file;
                }
                #endregion

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", product.CategoryID);
            ViewBag.FlavorID = new SelectList(db.Flavors, "FlavorID", "Name", product.FlavorID);
            ViewBag.NicotineID = new SelectList(db.Nicotines, "NicotineID", "StrengthMg", product.NicotineID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "Company", product.SupplierID);
            return View(product);
        }

        // GET: Products/Delete/5 | Management
        [Authorize(Roles = "Admin")]
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

        // POST: Products/Delete/5 | Management
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);

            string path = Server.MapPath("~/Content/imgstore/products/");
            ImageUtility.Delete(path, product.Image);

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

        // AJAX DELETE Products/AjaxDelete/5 | Management
        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Admin")]
        public JsonResult AjaxDelete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();

            string confirmMessage = string.Format($"Product \"{product.Name}\" deleted successfully!");

            return Json(new { id = id, message = confirmMessage });
        }

        // POST: Products/AddToCart/5 | Shopping
        [HttpPost]
        public ActionResult AddToCart(int qty, int productID)
        {
            Dictionary<int, CartItemViewModel> shoppingCart = null;

            if (Session["cart"] != null)
            {
                shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];
            }
            else
            {
                shoppingCart = new Dictionary<int, CartItemViewModel>();
            }

            Product product = db.Products.Where(p => p.ProductID == productID).FirstOrDefault();

            if (product == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                CartItemViewModel item = new CartItemViewModel(qty, product);

                if (shoppingCart.ContainsKey(product.ProductID))
                {
                    shoppingCart[product.ProductID].Qty += qty;
                }
                else
                {
                    shoppingCart.Add(product.ProductID, item);
                }

                Session["cart"] = shoppingCart;
            }

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
