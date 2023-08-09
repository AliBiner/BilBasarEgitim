using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Repositories.AdminRepository;

namespace BilBasarEgitim.Services
{
    public class AdminService
    {
        private readonly AdminRepository _adminRepository = new AdminRepository();
        public string Add(AdminRegisterDto dto)
        {
            try
            {
                var control = _adminRepository.GetAll(dto.Email);
                if (control == true)
                {
                    return "Zaten Sisteme Kayıtlı Bir Admin Bulunmaktadır.";
                }
                else
                {
                    var model = CustomMapper.AdminRegisterDtoto(dto);
                    _adminRepository.Add(model);
                    return "İşlem Başarılı";
                }

            }
            catch (Exception e)
            {
                return "İşlem Hatası: " + " " + e.Message;
            }
           
        }

        public string Login(AdminLoginDto dto)
        {
            try
            {
                var model = _adminRepository.LoginControl(dto.Email, dto.Password);
                if (model == null)
                {
                    return "Eposta veya Şifre Yanlış Olabilir";
                }
                else
                {
                    SetSession(model);
                    return "İşlem Başarılı";

                }
            }
            catch (Exception e)
            {
                return "İşlem Hatası: " + " " + e.Message;
            }
           
        }

        private void SetSession(Admin entity)
        {
            HttpContext.Current.Session["FullName"] = entity.FullName;
            HttpContext.Current.Session["Email"] = entity.Email;
            HttpContext.Current.Session["Id"] = entity.Id;
        }

        public void Logout()
        {
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
        }

        public string Update(AdminProfileUpdateDto dto)
        {
            try
            {
                var model = CustomMapper.AdminProfileUpdateDtoTo(dto);
                _adminRepository.Update(model);
                var admin = _adminRepository.GetById(dto.Id);
                SetSession(admin);
                return "İşlem Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "İşlem Hatası: " + e.Message;
            }
           
        }

        public string UpdatePassword(AdminChangePasswordDto dto)
        {
            try
            {
                var model = _adminRepository.GetById(dto.Id);
                if (model.Password != dto.CurrentPassword)
                {
                    return "Mevcut Şifre Hatalı";
                }
                else
                {
                    var admin = CustomMapper.AdminChangePasswordDtoTo(dto);
                    _adminRepository.UpdatePassword(admin);
                    return "";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
           
        }
    }
}