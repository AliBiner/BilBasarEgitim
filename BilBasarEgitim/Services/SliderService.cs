using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Repositories;

namespace BilBasarEgitim.Services
{
    public class SliderService
    {
        private SliderRepository sliderRepository = new SliderRepository();
        public string Add(SliderAddDto dto,HttpPostedFileBase slider)
        {
            try
            {
                var sliderUrl = CustomMethod.ImageUpload(slider);
                dto.ImageUrl = sliderUrl;
                var model = CustomMapper.SliderAddDtoTo(dto);
                sliderRepository.Add(model);
                return "Kayıt İşlemi Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "İşlem Hatası: " + " " + e.Message;
            }
            
        }
    }
}