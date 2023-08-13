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
                name: "AdminAkademikKadroSilRoute",
                url: "admin/akademik-kadro/sil/{id}",
                defaults: new { controller = "AdminAcademicStaff", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminAkademikKadroGuncelleRoute",
                url: "admin/akademik-kadro/guncelle/{id}",
                defaults: new { controller = "AdminAcademicStaff", action = "Update", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminAkademikKadroRoute",
                url: "admin/akademik-kadro",
                defaults: new { controller = "AdminAcademicStaff", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AdminAkademikKadroYukleRoute",
                url: "admin/akademik-kadro/yukle/{id}",
                defaults: new { controller = "AdminAcademicStaff", action = "Upload", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AdminHaberlerSilRoute",
                url: "admin/haberler/sil/{id}",
                defaults: new { controller = "AdminNews", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminHaberlerGuncelleRoute",
                url: "admin/haberler/guncelle/{id}",
                defaults: new { controller = "AdminNews", action = "Update", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminHaberlerYukleRoute",
                url: "admin/haberler/yukle/{id}",
                defaults: new { controller = "AdminNews", action = "Upload", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "AdminHaberlerRoute",
                url: "admin/haberler",
                defaults: new { controller = "AdminNews", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminDuyurularSilRoute",
                url: "admin/duyurular/sil/{id}",
                defaults: new { controller = "AdminNotice", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminDuyurularGuncelleRoute",
                url: "admin/duyurular/guncelle/{id}",
                defaults: new { controller = "AdminNotice", action = "Update", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminDuyurularYukleRoute",
                url: "admin/duyurular/yukle/{id}",
                defaults: new { controller = "AdminNotice", action = "Upload", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "AdminDuyurularRoute",
                url: "admin/duyurular",
                defaults: new { controller = "AdminNotice", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "AdminSliderSilRoute",
                url: "admin/slider/sil/{id}",
                defaults: new { controller = "AdminSlider", action = "Delete", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AdminSliderYayinlaRoute",
                url: "admin/slider/yayin-durumu/{id}",
                defaults: new { controller = "AdminSlider", action = "UpdateRelease", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AdminSliderRoute",
                url: "admin/slider",
                defaults: new { controller = "AdminSlider", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AdminSliderYukleRoute",
                url: "admin/slider/yukle/{id}",
                defaults: new { controller = "AdminSlider", action = "Upload", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "AdminProfilSifreDegisterRoute",
                url: "admin/profil/sifre-degister",
                defaults: new { controller = "Admin", action = "ChangePassword", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AdminProfilGuncelleRoute",
                url: "admin/profil/guncelle",
                defaults: new { controller = "Admin", action = "ProfileUpdate", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AdminProfilRoute",
                url: "admin/profil",
                defaults: new { controller = "Admin", action = "AdminProfile", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "CikisRoute",
            //    url: "Admin/Cikis",
            //    defaults: new { controller = "Admin", action = "SignOut", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "EmailRoute",
                url: "admin/email",
                defaults: new { controller = "AdminSendEmail", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DokumanlarRoute",
                url: "admin/dokumanlar",
                defaults: new { controller = "AdminDocument", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DokumanYukleRoute",
                url: "admin/dokumanlar/yukle",
                defaults: new { controller = "AdminDocument", action = "Add", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DokumanlarSillRoute",
                url: "admin/dokumanlar/sill/{id}",
                defaults: new { controller = "AdminDocument", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EgitimBasvuruOnaylananlarRoute",
                url: "admin/egitim-basvuru/onaylananlar",
                defaults: new { controller = "AdminEducationApply", action = "GetAllApproval", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EgitimBasvuruOnayRoute",
                url: "admin/egitim-basvuru/onay/{id}",
                defaults: new { controller = "AdminEducationApply", action = "Approval", id = UrlParameter.Optional }
            ); 
            routes.MapRoute(
                name: "EgitimBasvuruSilRoute",
                url: "admin/egitim-basvuru/sil/{id}",
                defaults: new { controller = "AdminEducationApply", action = "Delete", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EgitimBasvuruDetayRoute",
                url: "admin/egitim-basvuru/detay/{id}",
                defaults: new { controller = "AdminEducationApply", action = "EducationalApplyDetail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EgitimBasvuruRoute",
                url: "admin/egitim-basvuru",
                defaults: new { controller = "AdminEducationApply", action = "EducationalApply", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "IsBasvuruOnaylananlarRoute",
                url: "admin/is-basvuru/onaylananlar",
                defaults: new { controller = "AdminJobApply", action = "GetAllApproval", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DetayRoute",
                url: "admin/is-basvuru/detay/{id}",
                defaults: new { controller = "AdminJobApply", action = "JobApplyDetail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "OnaylaRoute",
                url: "admin/is-basvuru/onayla/{id}",
                defaults: new { controller = "AdminJobApply", action = "Approval", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ReddetRoute",
                url: "admin/is-basvuru/reddet/{id}",
                defaults: new { controller = "AdminJobApply", action = "Delete", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "IsBasvuruRoute",
                url: "admin/is-basvuru",
                defaults: new { controller = "AdminJobApply", action = "JobApply", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "KayitOlRoute",
                url: "kayit-ol",
                defaults: new { controller = "Admin", action = "Register", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "GirisYapRoute",
                url: "giris-yap",
                defaults: new { controller = "Admin", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "AnasayfaRoute",
             url: "anasayfa",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );

            routes.MapRoute(
                name: "HakkındaRoute",
                url: "hakkında",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Akademik-KadroRoute",
                url: "akademik-kadro",
                defaults: new { controller = "About", action = "AcademicStaff", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Yol-HaritasıRoute",
                url: "yol-haritasi",
                defaults: new { controller = "About", action = "RoadMap", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SubelerRoute",
                url: "subeler",
                defaults: new { controller = "About", action = "Branches", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HaberlerRoute",
                url: "haberler",
                defaults: new { controller = "Information", action = "News", id = UrlParameter.Optional }
            );
           
            routes.MapRoute(
                name: "DuyurularRoute",
                url: "duyurular",
                defaults: new { controller = "Information", action = "Notice", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GaleriRoute",
                url: "galeri",
                defaults: new { controller = "Gallery", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "YayinlarRoute",
                url: "yayinlar",
                defaults: new { controller = "TrainingPublication", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Öğrenci-PortalıRoute",
                url: "ogrenci-portali",
                defaults: new { controller = "StudentPortal", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Insan-KaynaklarıRoute",
                url: "insan-kaynaklari",
                defaults: new { controller = "HumanResources", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "IletisimRoute",
                url: "iletisim",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BasvuruRoute",
                url: "basvuru",
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
