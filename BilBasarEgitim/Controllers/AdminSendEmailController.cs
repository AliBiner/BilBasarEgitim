﻿using System;
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
    public class AdminSendEmailController : Controller
    {
        private readonly SendEmailService _emailService = new SendEmailService();
        // GET: AdminSendEmail
        public ActionResult Index()
        {
            var model =_emailService.GetEmail();
            Response.Cache.SetNoStore();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(SendEmailUpdateDto dto)
        {
            var result = _emailService.UpdateByEmail(dto.Id, dto.Email);
            Response.Cache.SetNoStore();
            return Content(result);
        }
    }
}