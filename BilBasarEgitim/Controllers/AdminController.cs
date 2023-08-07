using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.App_Start;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Services;

namespace BilBasarEgitim.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [CustomActionFilter]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(AdminRegisterDto dto)
        {
            AdminService adminService = new AdminService();
            var result = adminService.Add(dto);
            ViewBag.Error = result;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminLoginDto dto)
        {
            AdminService adminService = new AdminService();
            var result = adminService.Login(dto);
            if (result=="İşlem Başarılı")
            {
                return RedirectToAction("Index","Admin");
            }
            else
            {
                ViewBag.Error = result;
                return View();
            }
        }


       
    }
}