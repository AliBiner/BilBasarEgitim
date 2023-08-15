using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Dtos.News;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Models.News;
using BilBasarEgitim.Repositories;

namespace BilBasarEgitim.Services
{
    public class NewsService
    {
        private readonly NewsRepository newsRepository = new NewsRepository();
        public string Add(NewsAddDto dto)
        {
            try
            {
                var model = CustomMapper.NewsAddDtoTo(dto);
                var newsUrl = CustomMethod.NewsImageUpload(dto.NewsUrl);
                if (newsUrl == null)
                {
                    return "Resim Seçili Değil.";
                }
                model.ImageUrl = newsUrl;
                newsRepository.Add(model);
                return "Kayıt İşlemi Başarılı.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "İşlem Hatası";
            }

        }
        public List<NewsForAdminDto> GetAllNotDelete()
        {
            try
            {
                var modellist = newsRepository.GetAllNotDelete();
                var dtolist = CustomMapper.ToNewsDto(modellist);
                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public string Update(NewsUpdateDto dto, HttpPostedFileBase file)
        {
            try
            {
                var fileUrl = CustomMethod.NewsImageUpload(file);
                var model = CustomMapper.NewsUpdateDtoTo(dto);
                if (fileUrl == null)
                {
                    model.ImageUrl = dto.NewsUrl;
                }
                else
                {
                    model.ImageUrl = fileUrl;
                    CustomMethod.NewsImageDelete(dto.NewsUrl);
                }

                newsRepository.Update(model);
                return "Güncelleme İşlemi Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "İşlem Hatası";
            }

        }
        public void UpdateRelease(Guid id, bool check)
        {
            var model = new News()
            {
                Id = id,
                Check = check
            };
            newsRepository.UpdateRelease(model);
        }
        public void Delete(Guid id)
        {
            var newsUrl = newsRepository.GetById(id).ImageUrl;
            newsRepository.Delete(id);
            CustomMethod.NewsImageDelete(newsUrl);
        }
        public List<NewsForUserDto> GetAllOnlyUrl()
        {
            try
            {
                var modellist = newsRepository.GetAllForUser();
                var dtolist = CustomMapper.ToNewsForUserDto(modellist);
                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public NewsForAdminDto GetById(Guid id)
        {
            var model = newsRepository.GetById(id);
            var dto = CustomMapper.ToNewsForAdminDto(model);
            return dto;
        }
        public NewsUpdateDto GetByIdForUpdate(Guid id)
        {
            var model = newsRepository.GetById(id);
            var dto = CustomMapper.ToNewsUpdateDto(model);
            return dto;
        }
    }
}