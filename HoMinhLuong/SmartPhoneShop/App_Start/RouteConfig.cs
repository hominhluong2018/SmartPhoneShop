using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartPhoneShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "TatCaSanPham",
                url: "san-pham",
                defaults: new { controller = "Site", action = "Product" }
            );
            routes.MapRoute(
            name: "GioiThieu",
            url: "gioi-thieu",
            defaults: new { controller = "GioiThieu", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
                name: "TatCaBaiViet",
                url: "bai-viet",
                defaults: new { controller = "Site", action = "Post", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "GioHang",
             url: "gio-hang",
             defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "LienHe",
             url: "lien-he",
             defaults: new { controller = "Contacts", action = "Index" },
             namespaces: new[] { "SmartPhoneShop.Controllers" }
         );
            //URL cấp 1
            routes.MapRoute(
                name: "SiteSlug",
                url: "{slug}",
                defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
