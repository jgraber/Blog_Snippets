using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatchAllRule.Controllers
{
    public class EverythingController : Controller
    {
        // GET: Everything
        public ActionResult Index()
        {
            // use your logger to track outdated links:
            System.Diagnostics.Debug.WriteLine(
                $"Update link on page '{Request.UrlReferrer}' for '{Request.Url}'"
                );

            return View();
        }
    }
}