using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.App_Start;
using BilBasarEgitim.Models.Dtos.Gallery;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    [CustomActionFilter]
    public class AdminGalleryController : Controller
    {
        private readonly GalleryService galleryService = new GalleryService();
        // GET: AdminGallery
        public ActionResult Index()
        {
            var model = galleryService.GetAllNotDelete();
            Response.Cache.SetNoStore();
            return View(model);
        }

        public ActionResult Upload()
        {
            Response.Cache.SetNoStore();
            return View();
        }

        [HttpPost]
        public string Upload(GalleryAddDto dto)
        {
            Response.Cache.SetNoStore();
            var result = galleryService.Add(dto);
            return result;
        }

        [HttpGet]
        public ActionResult UpdateRelease(Guid Id, bool check)
        {
            galleryService.Update(Id, check);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid Id)
        {
            galleryService.Delete(Id);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }

        public ActionResult Placement()
        {
            var dtos = galleryService.GetAllForPlacement();
            Response.Cache.SetNoStore();
            return View(dtos);
        }
        [HttpPost]
        public ActionResult Placement(GalleryPlacementUpdateDto dtos)
        {
            galleryService.GalleryPlacementUpdate(dtos);
            Response.Cache.SetNoStore();
            return RedirectToAction("Placement");
        }
    }
}