using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Repositories.EducationalAppealRepository;

namespace BilBasarEgitim.Services
{
    public class EducationalAppealService
    {
        private readonly EducationalRepository _educationalRepository = new EducationalRepository();

        public string Add(EducationalAppealAddDto dto)
        {
            try
            {
                var model = CustomMapper.EducationalAppealAddDtoTo(dto);
                _educationalRepository.Add(model);
                return "İşlem Başarılı";
            }
            catch (Exception e)
            {
                return "İşlem Hatası: " + " " + e.Message;
            }
            
        }
    }
}