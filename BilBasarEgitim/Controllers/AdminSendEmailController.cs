using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.App_Start;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    [CustomActionFilter]
    public class AdminSendEmailController : Controller
    {
        private readonly SendEmailService _emailService = new SendEmailService();
        // GET: AdminSendEmail
        public ActionResult Index()
        {
            var model =_emailService.GetEmail();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Guid id , string Email)
        {
            _emailService.UpdateByEmail(id, Email);
            return RedirectToActionPermanent("Index");
        }
    }
}