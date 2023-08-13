using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos.AcademicStaff;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Repositories;

namespace BilBasarEgitim.Services
{
    public class AcademicStaffService
    {
        private readonly AcademicStaffRepository academic = new AcademicStaffRepository();

        public string Add(AcademicStaffAddDto dto)
        {
            try
            {
                var url = CustomMethod.AcademicStaffImageUpload(dto.File);
                if (url==null)
                {
                    return "Resim Seçiniz";
                }
                var model = CustomMapper.AcademicStaffAddDtoTo(dto);
                model.ImageUrl = url;
                academic.Add(model);
                return "Kayıt İşlemi Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "İşlem Hatası";
            }
            
        }
        public string Update(AcademicStaffUpdateDto dto)
        {
            try
            {

                var urlControl = CustomMethod.AcademicStaffImageUpload(dto.File);
                if (urlControl == null)
                {
                    var model = CustomMapper.AcademicStaffUpdateDtoTo(dto);
                    academic.Update(model);
                    
                }
                else
                {
                    CustomMethod.AcademicStaffImageDelete(dto.ImageUrl);
                    dto.ImageUrl = urlControl;
                    var model = CustomMapper.AcademicStaffUpdateDtoTo(dto);
                    academic.Update(model);
                    
                }

                return "Güncelleme İşlemi Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "İşlem Hatası";
            }
            
        }
        public void Delete(Guid id)
        {
            var url = academic.GetById(id).ImageUrl;
            academic.Delete(id);
            CustomMethod.AcademicStaffImageDelete(url);
        }

        public List<AcademicStaffPreviewForAdminDto> GetAll()
        {
            var model = academic.GetAll();
            var dtos = CustomMapper.ToAcademicStaffPreviewForAdminDtos(model);
            return dtos;
        }
        public void UpdateRelease(Guid id, bool check)
        {
            var model = new AcademicStaff()
            {
                Id = id,
                Check = check
            };
            academic.UpdateRelease(model);
        }

        public AcademicStaffUpdateDto GetById(Guid id)
        {
            var model = academic.GetById(id);
            var dto = CustomMapper.ToAcademicStaffUpdateDto(model);
            return dto;
        }

        public List<AcademicStaffForUserDto> GetAllForUser()
        {
            var model = academic.GetAllForUser();
            var dtos = CustomMapper.ToAcademicStaffForUserDtos(model);
            return dtos;
        }
    }
}