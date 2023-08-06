using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilBasarEgitim.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Notice()
        {
            return View();
        }
    }
}