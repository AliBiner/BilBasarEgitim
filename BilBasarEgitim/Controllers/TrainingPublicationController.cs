using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    public class TrainingPublicationController : Controller
    {
        private readonly TrainingPublicationService training = new TrainingPublicationService();
        // GET: TrainingPublication
        public ActionResult Index()
        {
            var model = training.GetAllForUser();
            Response.Cache.SetNoStore();
            return View(model);
        }
    }
}