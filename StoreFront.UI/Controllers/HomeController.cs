using StoreFront.UI.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using StoreFront.DATA;
using StoreFront.UI.Models;
using System.Configuration;

namespace StoreFront.UI.Controllers
{
    public class HomeController : Controller
    {
        private StoreFrontEntities db = new StoreFrontEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("ContactForm", cvm);
            }

            string message = $"You have received a new contact form submisson.<br /><br />" +
                                $"Name: {cvm.Name}<br />" +
                                $"Email: {cvm.Email}<br />" +
                                $"Message:<br /><br />" +
                                $"{cvm.Message}";

            MailMessage mm = new MailMessage(
                // FROM
                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                // TO
                ConfigurationManager.AppSettings["EmailTo"].ToString(),
                // SUBJECT
                "New contact form submission.",
                // MESSAGE
                message);

            mm.IsBodyHtml = true;
            mm.ReplyToList.Add(cvm.Email);
            mm.Priority = MailPriority.High;
    
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());
            client.Credentials = new NetworkCredential(
                // LOGIN
                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                // PASSWORD
                ConfigurationManager.AppSettings["EmailPass"].ToString());

            try
            {
                client.Send(mm);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"<div class=\"alert alert-danger\" role=\"alert\">Your message cannot be sent at this time.<br />Error: {ex.Message}</div>";

                return PartialView("ContactForm", cvm);
            }

            ModelState.Clear();
            ViewBag.Success = $"<div class=\"alert alert-success\" role=\"alert\">Message sent.</div>";
            return PartialView("ContactForm");
        }

        [HttpGet]
        public ActionResult Categories()
        {
            return View();
        }

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

        [HttpGet]
        public ActionResult Checkout()
        {
            var shoppingCart = (Dictionary<int, CartItemViewModel>)Session["cart"];

            if (shoppingCart == null || shoppingCart.Count() == 0)
            {
                shoppingCart = new Dictionary<int, CartItemViewModel>();
                ViewBag.Message = "Your shopping cart is empty.";
            }
            else
            {
                ViewBag.Message = null;
            }

            return View(shoppingCart);
        }

        [HttpGet]
        public ActionResult Styleguide()
        {
            return View();
        }
    }
}
