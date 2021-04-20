using StoreFront.UI.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;


namespace StoreFront.UI.Controllers
{
    public class HomeController : Controller
    {
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
            if (ModelState.IsValid)
            {
                string message = $"You have received a new contact form submisson.<br /><br />" +
                                 $"Name: {cvm.Name}<br />" +
                                 $"Email: {cvm.Email}<br />" +
                                 $"Message:<br /><br />" +
                                 $"{cvm.Message}";

                MailMessage mm = new MailMessage("admin@michaeljaggers.net", "michaeljaggers@outlook.com", "New contact form submission.", message);
                mm.IsBodyHtml = true;
                mm.ReplyToList.Add(cvm.Email);
                mm.Priority = MailPriority.High;

                SmtpClient client = new SmtpClient("mail.michaeljaggers.net");
                client.Credentials = new NetworkCredential("admin@michaeljaggers.net", "****");

                try
                {
                    client.Send(mm);
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = $"Your message could not be sent at this time.  Error: {e.Message}";
                }

                return View("EmailConfirmation");
            }

            return View(cvm);
        }

        [HttpGet]
        public ActionResult Categories()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cart()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Styleguide()
        {
            return View();
        }
    }
}
