using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MongoWebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "Person", "Person/{action}/{id}",
            //    defaults: new { controller = "Person", action = "List", id = UrlParameter.Optional });


            //routes.MapRoute(
            //    "Person", "Person/{name}",
            //    new
            //    {
            //        controller = "Person",
            //        action = "Search",
            //        name = UrlParameter.Optional
            //    });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
