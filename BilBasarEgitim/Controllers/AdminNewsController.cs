using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.App_Start;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Dtos.News;
using BilBasarEgitim.Models.News;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    [CustomActionFilter]
    public class AdminNewsController : Controller
    {
        private readonly NewsService newsService = new NewsService();
        // GET: AdminNews
        public ActionResult Index()
        {
            var model = newsService.GetAllNotDelete();
            return View(model);
        }

        public ActionResult Upload()
        {
            Response.Cache.SetNoStore();
            return View();
        }

        [HttpPost]
        public string Upload(NewsAddDto dto)
        {
            Response.Cache.SetNoStore();
            var result = newsService.Add(dto);
            return result;
        }
        public ActionResult Update(Guid id)
        {
            var model = newsService.GetByIdForUpdate(id);
            Response.Cache.SetNoStore();
            return View(model);
        }
        [HttpPost]
        public string Update(NewsUpdateDto dto, HttpPostedFileBase file)
        {
            var result = newsService.Update(dto, file);
            Response.Cache.SetNoStore();
            return result;
        }

        [HttpGet]
        public ActionResult UpdateRelease(Guid id, bool check)
        {
            newsService.UpdateRelease(id, check);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid Id)
        {
            newsService.Delete(Id);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }
    }
}