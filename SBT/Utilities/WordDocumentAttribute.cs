using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//This solution is based on http://benjii.me/2014/01/download-an-asp-net-mvc-view-as-a-word-document/.

namespace SBT.Utilities
{
    public class WordDocumentAttribute : ActionFilterAttribute
    {
        public string DefaultFilename { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result as ViewResult;

            if (result != null)
                result.MasterName = "~/Views/Shared/_WordLayout.cshtml";

            filterContext.Controller.ViewBag.WordDocumentMode = true;

            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var filename = filterContext.Controller.ViewBag.WordDocumentFilename;
            filename = filename ?? DefaultFilename ?? "Document";

            filterContext.HttpContext.Response.AppendHeader("Content-Disposition", string.Format("filename={0}.doc", filename));
            filterContext.HttpContext.Response.ContentType = "application/msword";

            base.OnResultExecuted(filterContext);
        }
    }
}