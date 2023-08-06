using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Models.Dtos;
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
                var control = _adminRepository.RegisterControl(dto.Email);
                if (control == true)
                {
                    return "Böyle Bir Email Zaten Kullanılmaktadır.";
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
    }
}