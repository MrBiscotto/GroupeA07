using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;

namespace GroupeA07
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RegisterRoute(RouteTable.Routes);
        }

        private static void RegisterRoute(RouteCollection routes)
        {
            routes.MapRoute("catchAll", "{*catchAll}", new { controller = "Index", action = "Index" });
        }
    }
}
