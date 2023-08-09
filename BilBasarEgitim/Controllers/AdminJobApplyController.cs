using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.App_Start;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    [CustomActionFilter]
    public class AdminJobApplyController : Controller
    {
        private readonly JobApplyService _applyService = new JobApplyService();
        // GET: AdminJobAppeal
        public ActionResult JobApply()
        {
           
            var model = _applyService.GetAllForPreview();
            return View(model);
        }
        
        [HttpGet]
        public ActionResult JobApplyDetail(Guid id)
        {
            var model = _applyService.GetById(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _applyService.DeleteById(id);
            return RedirectToAction("JobApply");

        }
        [HttpGet]
        public ActionResult Approval(Guid id)
        {
            _applyService.UpdateById(id);
            return RedirectToAction("JobApply");

        }
        public ActionResult GetAllApproval()
        {
            var model =_applyService.GetAllForApproval();
            return View(model);

        }
       
        
    }
}