using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    public class ApplyController : Controller
    {
        private readonly EducationalApplyService _applyService = new EducationalApplyService();
        // GET: Apply
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EducationalApplyAddDto dto)
        {
            var result =_applyService.Add(dto);
            ViewBag.Error = result;
            return View();
        }

    }
}