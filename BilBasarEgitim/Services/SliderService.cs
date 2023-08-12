using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Repositories;

namespace BilBasarEgitim.Services
{
    public class SliderService
    {
        private readonly SliderRepository sliderRepository = new SliderRepository();
        public string Add(SliderAddDto dto)
        {
            try
            {
                var model = CustomMapper.SliderAddDtoTo(dto);
                var sliderUrl = CustomMethod.SliderImageUpload(dto.ImageUrl);
                if (sliderUrl == null)
                {
                    return "Resim Seçili Değil.";
                }
                model.ImageUrl = sliderUrl;
                sliderRepository.Add(model);
                return "Kayıt İşlemi Başarılı.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "İşlem Hatası: " + " Kayıt İşlemi Başarısız." ;
            }
            
        }

        public List<SliderForAdminDto> GetAllNotDelete()
        {
            try
            {
                var modellist = sliderRepository.GetAllNotDelete();
                var dtolist = CustomMapper.ToSlidersDto(modellist);
                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void Update(Guid Id, bool check)
        {
            var slider = new Slider()
            {
                Id = Id,
                Check = check,
            };

            sliderRepository.Update(slider);
        }

        public void Delete(Guid id)
        {
            sliderRepository.Delete(id);
        }

        public List<SliderForUserDto> GetAllOnlyUrl()
        {
            try
            {
                var modellist = sliderRepository.GetAllOnlyUrl();
                var dtolist = CustomMapper.ToSliderForUserDto(modellist);
                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}