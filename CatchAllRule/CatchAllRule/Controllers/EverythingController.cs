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
            return View();
        }
    }
}