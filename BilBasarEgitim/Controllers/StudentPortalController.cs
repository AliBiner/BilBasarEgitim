using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    public class StudentPortalController : Controller
    {
        private DocumentService documentService = new DocumentService();
        // GET: StudentPortal
        public ActionResult Index()
        {
            var model = documentService.GetAll();
            return View(model);
        }
    }
}