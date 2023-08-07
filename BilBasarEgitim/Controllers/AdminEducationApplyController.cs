using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    public class AdminEducationApplyController : Controller
    {
        private readonly EducationalApplyService _educationalApplyService = new EducationalApplyService();
        public ActionResult EducationalApply()
        {
            var model=_educationalApplyService.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult EducationalApplyDetail(Guid id)
        {
            var model = _educationalApplyService.GetById(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _educationalApplyService.DeleteById(id);
            return RedirectToAction("EducationalApply");
        }
        [HttpGet]
        public ActionResult Approval(Guid id)
        {
            _educationalApplyService.UpdateById(id);
            return RedirectToAction("EducationalApply");
        }

    }
}