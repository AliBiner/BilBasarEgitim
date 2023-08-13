using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Repositories;

namespace BilBasarEgitim.Services
{
    public class NoticeService
    {
        public readonly NoticeRepository noticeRepository = new NoticeRepository();
        public string Add(NoticeAddDto dto)
        {
            try
            {
                var model = CustomMapper.NoticeAddDtoTo(dto);
                var noticeUrl = CustomMethod.NoticeImageUpload(dto.NoticeUrl);
                if (noticeUrl == null)
                {
                    return "Resim Seçili Değil.";
                }
                model.ImageUrl = noticeUrl;
                noticeRepository.Add(model);
                return "Kayıt İşlemi Başarılı.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "İşlem Hatası: " + " Kayıt İşlemi Başarısız.";
            }

        }

        public List<NoticeForAdminDto> GetAllNotDelete()
        {
            try
            {
                var modellist = noticeRepository.GetAllNotDelete();
                var dtolist = CustomMapper.ToNoticesDto(modellist);
                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public string Update(NoticeUpdateDto dto,HttpPostedFileBase file)
        {
            try
            {
                var fileUrl = CustomMethod.NoticeImageUpload(file);
                var model = CustomMapper.NoticeUpdateDtoTo(dto);
                if (fileUrl == null)
                {
                    model.ImageUrl = dto.NoticeUrl;
                }
                else
                {
                    model.ImageUrl = fileUrl;
                    CustomMethod.NoticeImageDelete(dto.NoticeUrl);
                }

                noticeRepository.Update(model);
                return "Güncelleme İşlemi Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "İşlem Hatası";
            }
            
        }
        public void UpdateRelease(Guid id, bool check)
        {
            var model = new Notice()
            {
                Id = id,
                Check = check
            };
            noticeRepository.UpdateRelease(model);
        }

        public void Delete(Guid id)
        {
            var noticeUrl = noticeRepository.GetById(id).ImageUrl;
            noticeRepository.Delete(id);
            CustomMethod.NoticeImageDelete(noticeUrl);
        }

        public List<NoticeForUserDto> GetAllOnlyUrl()
        {
            try
            {
                var modellist = noticeRepository.GetAllForUser();
                var dtolist = CustomMapper.ToNoticeForUserDto(modellist);
                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public NoticeForAdminDto GetById(Guid id)
        {
            var model = noticeRepository.GetById(id);
            var dto = CustomMapper.ToNoticeForAdminDto(model);
            return dto;
        }
        public NoticeUpdateDto GetByIdForUpdate(Guid id)
        {
            var model = noticeRepository.GetById(id);
            var dto = CustomMapper.ToNoticeUpdateDto(model);
            return dto;
        }
    }
}