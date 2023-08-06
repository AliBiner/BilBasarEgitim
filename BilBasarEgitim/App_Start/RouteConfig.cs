using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BilBasarEgitim
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "AnasayfaRoute",
             url: "Anasayfa",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );

            routes.MapRoute(
                name: "HakkındaRoute",
                url: "Hakkında",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Akademik-KadroRoute",
                url: "Akademik-Kadro",
                defaults: new { controller = "About", action = "AcademicStaff", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Yol-HaritasıRoute",
                url: "Yol-Haritası",
                defaults: new { controller = "About", action = "RoadMap", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SubelerRoute",
                url: "Subeler",
                defaults: new { controller = "About", action = "Branches", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HaberlerRoute",
                url: "Haberler",
                defaults: new { controller = "Information", action = "News", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DuyurularRoute",
                url: "Duyurular",
                defaults: new { controller = "Information", action = "Notice", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GaleriRoute",
                url: "Galeri",
                defaults: new { controller = "Gallery", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "YayınlarRoute",
                url: "Yayınlar",
                defaults: new { controller = "TrainingPublication", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Öğrenci-PortalıRoute",
                url: "Öğrenci-Portalı",
                defaults: new { controller = "StudentPortal", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Insan-KaynaklarıRoute",
                url: "Insan-Kaynakları",
                defaults: new { controller = "HumanResources", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "IletisimRoute",
                url: "Iletisim",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BasvuruRoute",
                url: "Basvuru",
                defaults: new { controller = "Appeal", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
