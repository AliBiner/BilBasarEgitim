using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        public ActionResult News()
        {
            NewsService newsService = new NewsService();
            var model = newsService.GetAllOnlyUrl();
            return View(model);
        }
        public ActionResult Notice()
        {
            NoticeService noticeService = new NoticeService();
            var model = noticeService.GetAllOnlyUrl();
            return View(model);
        }
    }
}