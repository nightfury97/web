using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SweepCake
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
              name: "Category",
              url: "product/{type}",
              defaults: new { controller = "product", action = "products", id = UrlParameter.Optional }
              //namespaces: new[] { "OnlineShop.Controllers" }
          );
            routes.MapRoute(
              name: "cakes",
              url: "detail/{id}",
              defaults: new { controller = "product", action = "detail", id = UrlParameter.Optional }
          //namespaces: new[] { "OnlineShop.Controllers" }
          );
            routes.MapRoute(
              name: "add",
              url: "AddCake",
              defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }
          //namespaces: new[] { "OnlineShop.Controllers" }
          );
            routes.MapRoute(
            name: "Cart",
            url: "Cart/Index",
            defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HomePage", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
