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
                name: "EmailRoute",
                url: "Admin/Email",
                defaults: new { controller = "AdminSendEmail", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DokumanlarRoute",
                url: "Admin/Dokumanlar",
                defaults: new { controller = "AdminDocument", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DokumanYukleRoute",
                url: "Admin/Dokumanlar/Yukle",
                defaults: new { controller = "AdminDocument", action = "Add", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DokumanlarSillRoute",
                url: "Admin/Dokumanlar/Sill/{id}",
                defaults: new { controller = "AdminDocument", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EgitimBasvuruOnaylananlarRoute",
                url: "Admin/EgitimBasvuru/Onaylananlar",
                defaults: new { controller = "AdminEducationApply", action = "GetAllApproval", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EgitimBasvuruOnayRoute",
                url: "Admin/EgitimBasvuru/Onay/{id}",
                defaults: new { controller = "AdminEducationApply", action = "Approval", id = UrlParameter.Optional }
            ); 
            routes.MapRoute(
                name: "EgitimBasvuruSilRoute",
                url: "Admin/EgitimBasvuru/Sil/{id}",
                defaults: new { controller = "AdminEducationApply", action = "Delete", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EgitimBasvuruDetayRoute",
                url: "Admin/EgitimBasvuru/Detay/{id}",
                defaults: new { controller = "AdminEducationApply", action = "EducationalApplyDetail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EgitimBasvuruRoute",
                url: "Admin/EgitimBasvuru",
                defaults: new { controller = "AdminEducationApply", action = "EducationalApply", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "IsBasvuruOnaylananlarRoute",
                url: "Admin/IsBasvuru/Onaylananlar",
                defaults: new { controller = "AdminJobApply", action = "GetAllApproval", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DetayRoute",
                url: "Admin/IsBasvuru/Detay/{id}",
                defaults: new { controller = "AdminJobApply", action = "JobApplyDetail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "OnaylaRoute",
                url: "Admin/IsBasvuru/Onayla/{id}",
                defaults: new { controller = "AdminJobApply", action = "Approval", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ReddetRoute",
                url: "Admin/IsBasvuru/Reddet/{id}",
                defaults: new { controller = "AdminJobApply", action = "Delete", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "IsBasvuruRoute",
                url: "Admin/IsBasvuru",
                defaults: new { controller = "AdminJobApply", action = "JobApply", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "KayitOlRoute",
                url: "KayitOl",
                defaults: new { controller = "Admin", action = "Register", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "GirisYapRoute",
                url: "GirisYap",
                defaults: new { controller = "Admin", action = "Login", id = UrlParameter.Optional }
            );
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
                defaults: new { controller = "Apply", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
