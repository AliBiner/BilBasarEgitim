using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilBasarEgitim.Controllers
{
    public class AdminDocumentController : Controller
    {
        
        // GET: AdminDocument
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return RedirectToActionPermanent("Index");
        }
        [HttpGet]
        public ActionResult Add()
        {
            return RedirectToActionPermanent("Index");
        }
    }
}