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
                url: "GZ/{action}/{id}",
                defaults: new { controller = "WXGZ", action = "InputSN", id = UrlParameter.Optional }
            );
           // routes.MapRoute(
           //    name: "QY",
           //    url: "QY/{controller}/{action}/{id}",
           //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           //);
           // routes.MapRoute(
           //    name: "API",
           //    url: "API/{controller}/{action}/{id}",
           //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           //);
        }
    }
}