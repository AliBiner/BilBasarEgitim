using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Repositories.EducationalAppealRepository;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    public class AppealController : Controller
    {
        // GET: Appeal
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EducationalAppealAddDto dto)
        {
            EducationalAppealService _appealService = new EducationalAppealService();
            var result =_appealService.Add(dto);
            ViewBag.Error = result;
            return View();
        }
    }
}