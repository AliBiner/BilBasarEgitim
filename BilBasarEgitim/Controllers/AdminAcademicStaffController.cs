using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.App_Start;
using BilBasarEgitim.Models.Dtos.AcademicStaff;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    [CustomActionFilter]
    public class AdminAcademicStaffController : Controller
    {
        private readonly AcademicStaffService academic = new AcademicStaffService();
        // GET: AdminAcademicStaff
        public ActionResult Index()
        {
            var model = academic.GetAll();
            Response.Cache.SetNoStore();
            return View(model);
        }

        public ActionResult Upload()
        {
            Response.Cache.SetNoStore();
            return View();
        }

        [HttpPost]
        public string Upload(AcademicStaffAddDto dto)
        {
            var result = academic.Add(dto);
            Response.Cache.SetNoStore();
            return result;
        }

        public ActionResult Update(Guid id)
        {
            var model = academic.GetById(id);
            return View(model);
        }

        [HttpPost]
        public string Update(AcademicStaffUpdateDto dto)
        {
            var result = academic.Update(dto);
            Response.Cache.SetNoStore();
            return result;
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            academic.Delete(id);
            Response.Cache.SetNoStore();
            return RedirectToActionPermanent("Index");
        }

        [HttpGet]
        public ActionResult UpdateRelease(Guid id, bool check)
        {
            academic.UpdateRelease(id, check);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }

    }
}