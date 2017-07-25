using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HangfireDemo
{
    using Hangfire;

    using Serilog;

    using StackExchange.Profiling;

    public class MvcApplication : System.Web.HttpApplication
    {
        private BackgroundJobServer _backgroundJobServer;

        protected void Application_Start()
        {
            MiniProfiler.Settings.Results_List_Authorize = IsUserAllowedToSeeMiniProfilerUI;

            var log =
                new LoggerConfiguration().ReadFrom.AppSettings()
                    .CreateLogger();
            Log.Logger = log;

            // Configure Hangfire
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("HangfireDB")
                .UseSerilogLogProvider();

            //_backgroundJobServer = new BackgroundJobServer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _backgroundJobServer.Dispose();
        }

        protected void Application_BeginRequest()
        {
            if (Request.IsLocal)
            {
                MiniProfiler.Start();
            }

            BackgroundJob.Enqueue(() => Log.Information("Hello, world! {time}", DateTime.Now));
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }

        private bool IsUserAllowedToSeeMiniProfilerUI(HttpRequest httpRequest)
        {
            return true;
        }
    }
}
