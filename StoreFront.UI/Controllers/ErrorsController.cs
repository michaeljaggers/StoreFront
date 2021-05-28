using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreFront.UI.Exceptions;

namespace StoreFront.UI.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Throw404()
        {
            return HttpNotFound();
        }

        public ActionResult Unresolved()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult DBTest()
        {
            try
            {
                bool dbCheck = false;

                if (dbCheck)
                {
                    return View();
                }
                else
                {
                    throw new DBOfflineException();
                }
            }
            catch (Exception)
            {

                return RedirectToAction("DBOffline");
            }
        }

        public ActionResult DBOffline()
        {
            return View();
        }
    }
}