using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.App_Start;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    [CustomActionFilter]
    public class AdminDocumentController : Controller
    {
        private readonly DocumentService _documentService = new DocumentService();
        // GET: AdminDocument
        public ActionResult Index()
        {

            var model = _documentService.GetAll();
            Response.Cache.SetNoStore();
            return View(model);
           
           
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(DocumentAddDto dto ,HttpPostedFileBase document)
        {
            _documentService.Add(dto, document);
            Response.Cache.SetNoStore();
            return RedirectToActionPermanent("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            _documentService.Delete(id);
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");

        }
    }
}