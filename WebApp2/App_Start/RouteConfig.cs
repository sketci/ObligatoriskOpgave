using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
          name: "BilForside",
          url: "BilForside",
          defaults: new { controller = "Bil", action = "BilForside" }
            );

            routes.MapRoute(
          name: "BrugerForside",
          url: "BrugerForside",
          defaults: new { controller = "Bruger", action = "BrugerForside" }
            );

            routes.MapRoute(
          name: "Velkmostside",
          url: "Velkomstside",
          defaults: new { controller = "Velkomst", action = "Velkomstside" }
            );

            routes.MapRoute(
                name: "CatchAll",
                url: "{*url}",
                defaults: new { controller = "Velkomst", action = "Velkomstside" }
            );
        }
    }
}
