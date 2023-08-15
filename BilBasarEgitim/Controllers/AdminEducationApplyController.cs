using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.App_Start;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    [CustomActionFilter]
    public class AdminEducationApplyController : Controller
    {
        private readonly EducationalApplyService _educationalApplyService = new EducationalApplyService();
        public ActionResult EducationalApply()
        {
            var model = _educationalApplyService.GetAll();
            Response.Cache.SetNoStore();
            return View(model);
            
            
        }
        [HttpGet]
        public ActionResult EducationalApplyDetail(Guid id)
        {
            var model = _educationalApplyService.GetById(id);
            Response.Cache.SetNoStore();
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _educationalApplyService.DeleteById(id);
            Response.Cache.SetNoStore();
            return RedirectToAction("EducationalApply");
        }
        [HttpGet]
        public ActionResult DeleteApproval(Guid id)
        {
            _educationalApplyService.DeleteById(id);
            Response.Cache.SetNoStore();
            return RedirectToAction("GetAllApproval");
        }
        [HttpGet]
        public ActionResult Approval(Guid id)
        {
            _educationalApplyService.UpdateById(id);
            Response.Cache.SetNoStore();
            return RedirectToAction("EducationalApply");
        }
        public ActionResult GetAllApproval()
        {
            var model =_educationalApplyService.GetAllForApproval();
            Response.Cache.SetNoStore();
            return View(model);
        }

    }
}