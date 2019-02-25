using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HangfireDemo
{
    using System.Threading;

    using Hangfire;

    using Serilog;

    using StackExchange.Profiling;

    public class MvcApplication : System.Web.HttpApplication
    {
        private BackgroundJobServer _backgroundJobServer;

        protected void Application_Start()
        {
            MiniProfiler.Configure(new MiniProfilerOptions
                {
                    // Sets up the route to use for MiniProfiler resources:
                    // Here, ~/profiler is used for things like /profiler/mini-profiler-includes.js
                    RouteBasePath = "~/profiler",
                    // ResultsAuthorize (optional - open to all by default):
                    // because profiler results can contain sensitive data (e.g. sql queries with parameter values displayed), we
                    // can define a function that will authorize clients to see the JSON or full page results.
                    // we use it on http://stackoverflow.com to check that the request cookies belong to a valid developer.
                    ResultsAuthorize = request => request.IsLocal,

                    // ResultsListAuthorize (optional - open to all by default)
                    // the list of all sessions in the store is restricted by default, you must return true to allow it
                    ResultsListAuthorize = request =>
                    {
                        // you may implement this if you need to restrict visibility of profiling lists on a per request basis
                        return true; // all requests are legit in this example
                    }
                }
            );

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
            if (Request.IsLocal) // Example of conditional profiling, you could just call MiniProfiler.StartNew();
            {
                MiniProfiler.StartNew();
            }

            BackgroundJob.Enqueue(
                () => Thread.Sleep(4000)); 
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Current?.Stop();
        }

        private bool IsUserAllowedToSeeMiniProfilerUI(HttpRequest httpRequest)
        {
            return true;
        }
    }
}
