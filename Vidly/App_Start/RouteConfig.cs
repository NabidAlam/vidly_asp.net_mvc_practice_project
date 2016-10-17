using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //MapRoutes must be defined in order of decreasing specificity

            //enable attribute routing
            routes.MapMvcAttributeRoutes();

            //conventional route setting technique
            //routes.MapRoute(
            //    name: "MoviesByReleaseDate",
            //    url: "movies/released/{year}/{month}",
            //    defaults: new {controller = "Movies", action = "ByReleaseDate"},
            //    constraints: new { year = @"\d{4}", month = @"\d{2}" } //year passed into URL as param must be 4 digit and month param must be 2 digit
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
