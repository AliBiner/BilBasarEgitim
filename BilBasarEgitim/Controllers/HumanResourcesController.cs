using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Repositories.JobAppealRepository;
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
        public ActionResult Index(JopAppealAddDto dto,HttpPostedFileBase cv)
        {
            JobAppealService _appealService = new JobAppealService();
            var result = _appealService.AddJobAppealWithCv(dto,cv);
            ViewBag.Error = result;
            return View();
        }
    }
}