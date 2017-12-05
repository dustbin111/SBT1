using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SBT.Models;

namespace SBT.Controllers
{
    public class AssetsController : Controller
    {
        // GET: Assets
        public ActionResult Index()
        {
            SessionViewModel viewModel = GetViewModel();

            // if the model is valid and there are assets (any is a null and length check condensed)
            if (viewModel == null || !viewModel.Assets.Any())
            {
                return RedirectToAction("Asset", "SecBase");
            }

            return View(viewModel.Assets);
        }

        public SessionViewModel GetViewModel()
        {
            var viewModel = new SessionViewModel();

            // Check and see if something is in memory
            if (Session["SBT"] != null)
            {
                viewModel = (SessionViewModel)Session["SBT"];
            }

            return viewModel;
        }
    }
}