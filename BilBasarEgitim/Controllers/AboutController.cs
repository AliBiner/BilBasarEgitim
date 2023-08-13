using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AcademicStaff()
        {
            AcademicStaffService academic = new AcademicStaffService();
            var model = academic.GetAllForUser();
            return View(model);
        }
        public ActionResult Branches()
        {
            return View();
        }
        public ActionResult RoadMap()
        {
            return View();
        }
    }
}