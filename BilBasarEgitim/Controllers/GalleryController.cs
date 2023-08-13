using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    public class GalleryController : Controller
    {
        private GalleryService galleryService = new GalleryService();
        // GET: Gallery
        public ActionResult Index()
        {
            var model = galleryService.GetAllForUser();
            return View(model);
        }
    }
}