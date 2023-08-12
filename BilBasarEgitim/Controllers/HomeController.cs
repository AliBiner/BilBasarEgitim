using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Repositories.AdminRepository;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            SliderService sliderService = new SliderService();
            var model = sliderService.GetAllOnlyUrl();
            return View(model);
        }
    }
}