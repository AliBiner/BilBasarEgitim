using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    public class HumanResourcesController : Controller
    {
        // GET: HumanResources
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(JopApplyAddDto dto,HttpPostedFileBase cv)
        {
            JobApplyService applyService = new JobApplyService();
            var result = applyService.AddJobAppealWithCv(dto,cv);
            ViewBag.Error = result;
            Response.Cache.SetNoStore();
            return View();
        }
    }
}