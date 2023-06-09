﻿using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "BilForside", url: "BilForside",
                defaults: new { controller = "Bil", action = "BilForside" });

            routes.MapRoute(name: "SorterÅr", url: "Bil/SorterAar",
                            defaults: new
                            {
                                controller = "Bil",
                                action = "SorterÅr",
                                id = UrlParameter.Optional
                            });

            routes.MapRoute(
                name: "FindBilMærke", url: "Bil/FindBilMaerke",
                defaults: new
                {
                    controller = "Bil",
                    action = "FindBilMærke",
                    id = UrlParameter.Optional
                });

            routes.MapRoute(
                name: "HentAlleBrugere", url: "Bruger/HentAlleBrugere",
                defaults: new
                {
                    controller = "Bruger",
                    action = "HentAlleBrugere",
                    id = UrlParameter.Optional
                });

            routes.MapRoute(
                name: "BrugerForside", url: "BrugerForside",
                defaults: new { controller = "Bruger", action = "BrugerForside" });

            routes.MapRoute(
               name: "BrugerDetails", url: "Bruger/BrugerDetails/{id}",
               defaults: new { controller = "Bruger", action = "BrugerDetails", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Velkmostside", url: "Velkomstside",
                defaults: new { controller = "Velkomst", action = "Velkomstside" });

            routes.MapRoute(
                name: "CatchAll", url: "{*url}",
                defaults: new { controller = "Velkomst", action = "Velkomstside" });
        }
    }
}
