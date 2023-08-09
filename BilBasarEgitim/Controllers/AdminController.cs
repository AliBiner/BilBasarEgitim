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

        [HttpPost]
        public ActionResult Logout()
        {
            AdminService adminService = new AdminService();
            adminService.SignOut();
            return RedirectToActionPermanent("Index");
        }

        [CustomActionFilter]
        public ActionResult AdminProfile(string result)
        {
            if (result == null)
            {
                return View();
            }
            else
            {
                ViewBag.Message = result;
                return View();
            }
        }
            

        [CustomActionFilter]
        public ActionResult ProfileUpdate()
        {
            return PartialView();
        }

        [CustomActionFilter]
        [HttpPost]
        public ActionResult ProfileUpdate(AdminProfileUpdateDto dto)
        {
            AdminService adminService = new AdminService();
            adminService.Update(dto);
            return RedirectToActionPermanent("AdminProfile");
        }


        [CustomActionFilter]
        public ActionResult ChangePassword()
        {
            return PartialView();
        }

        [CustomActionFilter]
        [HttpPost]
        public ActionResult ChangePassword(AdminChangePasswordDto dto)
        {
            AdminService adminService = new AdminService();
            var result = adminService.UpdatePassword(dto);
            return RedirectToActionPermanent("AdminProfile","Admin",new {result = result});
        }

    }
}