using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.App_Start;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{  
    [CustomActionFilter]
    public class AdminSliderController : Controller
    {
        private readonly SliderService sliderService = new SliderService();
        // GET: AdminSlider
        public ActionResult Index()
        {
            var model = sliderService.GetAllNotDelete();
            Response.Cache.SetNoStore();
            return View(model);
        }

        public ActionResult Upload()
        {
            Response.Cache.SetNoStore();
            return View();
        }

        [HttpPost]
        public string Upload(SliderAddDto dto)
        {
            Response.Cache.SetNoStore();
            var result = sliderService.Add(dto);
            return result;
        }

        //[HttpGet]
        //public ActionResult NonRelease(Guid Id)
        //{
        //    sliderService.UpdateRelease(Id,false);
        //    return RedirectToActionPermanent("Index");
        //}

        [HttpGet]
        public ActionResult UpdateRelease(Guid Id,bool check)
        {
            sliderService.Update(Id, check);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid Id)
        {
            sliderService.Delete(Id);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }
    }
}