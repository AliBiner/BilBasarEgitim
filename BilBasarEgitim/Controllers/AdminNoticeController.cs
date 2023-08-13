using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BilBasarEgitim.App_Start;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    [CustomActionFilter]
    public class AdminNoticeController : Controller
    {
        private readonly NoticeService noticeService = new NoticeService();
        // GET: AdminNotice
        public ActionResult Index()
        {
            var model = noticeService.GetAllNotDelete();
            Response.Cache.SetNoStore();
            return View(model);
        }

        public ActionResult Upload()
        {
            Response.Cache.SetNoStore();
            return View();
        }

        [HttpPost]
        public string Upload(NoticeAddDto dto)
        {
            Response.Cache.SetNoStore();
            var result = noticeService.Add(dto);
            return result;
        }
        public ActionResult Update(Guid id)
        {
            var model = noticeService.GetByIdForUpdate(id);
            Response.Cache.SetNoStore();
            return View(model);
        }
        [HttpPost]
        public string Update(NoticeUpdateDto dto, HttpPostedFileBase file)
        {
            var result = noticeService.Update(dto,file);
            Response.Cache.SetNoStore();
            return result;
        }

        [HttpGet]
        public ActionResult UpdateRelease(Guid id ,bool check)
        {
            noticeService.UpdateRelease(id,check);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid Id)
        {
            noticeService.Delete(Id);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }
    }
}