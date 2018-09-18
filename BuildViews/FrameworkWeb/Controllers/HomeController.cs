using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrameworkWeb.Models;

namespace FrameworkWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            var companyInfo = new CompanyInfo {Name = "Demo", PhoneNumber = "555 xxx xxx"};

            ViewBag.Message = "Your contact page.";

            return View(companyInfo);
        }
    }
}