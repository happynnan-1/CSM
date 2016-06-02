using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CSM
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GZ",
                url: "GZ/{action}/{para}",
                defaults: new { controller = "GZ", action = "InputSN", para=""}
            );
            routes.MapRoute(
               name: "QY",
               url: "QY/{action}/{para}",
               defaults: new { controller = "QY", action = "", para = "" }
           );
            routes.MapRoute(
              name: "API",
              url: "API/{action}/{para}",
              defaults: new { controller = "API", action = "", para = "" }
          );
        }
    }
}