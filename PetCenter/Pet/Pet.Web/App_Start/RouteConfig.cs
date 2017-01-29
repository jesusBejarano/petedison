using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pet.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                //defaults: new { controller = "CartillaAtencion", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Cartilla",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "GEL_CartillaAtencion", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}