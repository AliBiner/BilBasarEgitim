using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
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