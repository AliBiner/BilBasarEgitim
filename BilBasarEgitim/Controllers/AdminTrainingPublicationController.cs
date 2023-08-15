using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.App_Start;
using BilBasarEgitim.Models.Dtos.TrainingPublication;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    [CustomActionFilter]
    public class AdminTrainingPublicationController : Controller
    {
        private readonly TrainingPublicationService training = new TrainingPublicationService();
        // GET: AdminTrainingPublication
        public ActionResult Index()
        {
            var model = training.GetAllNotDelete();
            Response.Cache.SetNoStore();
            return View(model);
        }

        public ActionResult Upload()
        {
            Response.Cache.SetNoStore();
            return View();
        }

        [HttpPost]
        public string Upload(TrainingPublicationAddDto dto)
        {
            Response.Cache.SetNoStore();
            var result = training.Add(dto);
            return result;
        }

        [HttpGet]
        public ActionResult UpdateRelease(Guid Id, bool check)
        {
            training.Update(Id, check);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid Id)
        {
            training.Delete(Id);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }

        public ActionResult Placement()
        {
            var dtos = training.GetAllForPlacement();
            Response.Cache.SetNoStore();
            return View(dtos);
        }
        [HttpPost]
        public ActionResult Placement(TrainingPublicationPlacementUpdateDto dtos)
        {
            training.TrainingPublicationPlacementUpdate(dtos);
            Response.Cache.SetNoStore();
            return RedirectToAction("Placement");
        }
    }
}