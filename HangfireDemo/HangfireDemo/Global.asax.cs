using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HangfireDemo
{
    using Serilog;
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var log =
                new LoggerConfiguration().ReadFrom.AppSettings()
                    .CreateLogger();
            Log.Logger = log;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
