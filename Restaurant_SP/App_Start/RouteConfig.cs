using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Restaurant_SP
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
            );

            routes.MapRoute(
                name: "Rooms",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Room", action = "", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Booking",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Booking", action = "", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "User",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "", id = UrlParameter.Optional }
            );
        }
    }
}
    

