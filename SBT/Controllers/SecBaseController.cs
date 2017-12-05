using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using SBT.Models;
using SBT.Utilities;

namespace SBT.Controllers
{
    public class SecBaseController : Controller
    {
        // GET: SecBase
        public ActionResult Index()
        {
            return View();
        }

        // GET: SecBase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SecBase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SecBase/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SecBase/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SecBase/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SecBase/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SecBase/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // -------------------------------------------------------------------------------------------------------------------------------
        // GET: SecBase/Asset
        public ActionResult Asset(string id)
        {
            var viewModel = GetViewModel();

            SBTAsset asset = new SBTAsset();

            if (!string.IsNullOrEmpty(id) && viewModel.Assets.Any(x => x.assetID == id))
            {
                asset = viewModel.Assets.First(x => x.assetID == id);
            }

            ViewBag.catPiefaos = GetPIEFAOS();

            ViewBag.catIBTL = GetIBTLCat();

            ViewBag.catIBTLSub = GetIBTLSubCat();

            return View(asset);
        }

        // POST: SecBase/Asset
        [HttpPost]
        public ActionResult Asset(SBTAsset asset, string direction)
        {
            SessionViewModel viewModel = GetViewModel();

            if (viewModel.Assets == null)
            {
                viewModel.Assets = new List<SBTAsset>();
            }

            viewModel.Assets.Add(asset);

            Session["SBT"] = viewModel;
            if (!string.IsNullOrEmpty(direction))
            {
                return RedirectToAction(direction);
            }

            ViewBag.catPiefaos = GetPIEFAOS();

            ViewBag.catIBTL = GetIBTLCat();

            ViewBag.catIBTLSub = GetIBTLSubCat();

            return View(viewModel.Asset);
        }

        // -------------------------------------------------------------------------------------------------------------------------------
        // GET: SecBase/Facility
        public ActionResult Facility()
        {

            ViewBag.States = GetStates();

            //return View();
            return View(GetViewModel().Facility);
        }

        // POST: SecBase/Facility
        [HttpPost]
        public ActionResult Facility(SBTFacility facility, string direction)
        {
            SessionViewModel viewModel = GetViewModel();

            viewModel.Facility = facility;
            Session["SBT"] = viewModel;
            if (!string.IsNullOrEmpty(direction))
            {
                return RedirectToAction(direction);
            }

            ViewBag.States = GetStates();

            return View(viewModel.Facility);
        }


        // -------------------------------------------------------------------------------------------------------------------------------
        public ActionResult WarningBanner()
        {
            return View();
        }

        public ActionResult Export()
        {
            return View();
        }

        public ActionResult Import()
        {
            return View();
        }

        // GET: SecBase/SecurityBaselineTemplate
        [WordDocument(DefaultFilename = "CAGE - Security Baseline")]
        public ActionResult SecurityBaselineTemplate()
        {
            var viewModel = GetViewModel();

            ViewBag.WordDocumentFilename = viewModel.Facility.FacilityCAGE;

            return View(viewModel);
        }

        //What does this do?
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

        public IEnumerable<SelectListItem> GetStates()
        {
            //This populates the State dropdown from XML.
            string path = Server.MapPath("~/XML/StateLookup.xml");
            var t = XDocument.Load(path).Descendants("state");
            IEnumerable<SelectListItem> states = from xmlNode in
                             XDocument.Load(path).Descendants("state")
                                                  select new SelectListItem
                                                  {
                                                      Text = (string)xmlNode.Attribute("name")
                                                  };
            return states;
        }

        public IEnumerable<SelectListItem> GetPIEFAOS()
        {
            //This populates the PIEFAOS dropdown from XML.
            string path = Server.MapPath("~/XML/PIEFAOS.xml");
            var i = XDocument.Load(path).Descendants("piefaosItemTable");
            IEnumerable<SelectListItem> PIEFAOSCat = from proc in
                                XDocument.Load(path).Descendants("piefaosItemRow")
                                                    select new SelectListItem
                                                    {
                                                        Text = (string)proc.Element("piefaosCategory")
                                                        //Text = (string)proc.Attribute("piefaosCategory")
                                                    };
            return PIEFAOSCat;
        }

        public IEnumerable<SelectListItem> GetIBTLCat()
        {
            //This populates the IBTL dropdown from XML.
            string pathIBTL = Server.MapPath("~/XML/IBTL.xml");
            var t = XDocument.Load(pathIBTL).Descendants("ibtlItemTable");
            IEnumerable<SelectListItem> processIBTL = from proc in
                             XDocument.Load(pathIBTL).Descendants("ibtlItemRow")
                                                      select new SelectListItem
                                                      {
                                                          Text = (string)proc.Element("ibtlCategory")
                                                          //Text = (string)proc.Attribute("ibtlCategory")

                                                      };
            return processIBTL;
        }

        public IEnumerable<SelectListItem> GetIBTLSubCat()
        {
            //This populates the IBTL dropdown from XML.
            string pathIBTLSub = Server.MapPath("~/XML/IBTL.xml");
            var s = XDocument.Load(pathIBTLSub).Descendants("ibtlItemTable");
            IEnumerable<SelectListItem> processIBTLSub = from proc in
                             XDocument.Load(pathIBTLSub).Descendants("ibtlItemRow")
                                                         select new SelectListItem
                                                         {
                                                             Text = (string)proc.Element("ibtlArea")
                                                             //Text = (string)proc.Attribute("ibtlArea")

                                                         };
            return processIBTLSub;
        }

        public ActionResult FOCI()
        {
            return View();
        }


    }
}
