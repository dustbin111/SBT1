using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Automated creation of a security basline.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "The Contact Page.";

            return View();
        }

        //GET: SecBase/WarningBanner
        public ActionResult WarningBanner()
        {
              return View();
        }
    }
}