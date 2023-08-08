using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Repositories.EducationalApplyRepository;

namespace BilBasarEgitim.Services
{
    public class EducationalApplyService
    {
        private readonly EducationalApplyRepository _educationalApplyRepository = new EducationalApplyRepository();

        public string Add(EducationalApplyAddDto dto)
        {
            try
            {
                var model = CustomMapper.EducationalAppealAddDtoTo(dto);
                _educationalApplyRepository.Add(model);
                return "İşlem Başarılı";
            }
            catch (Exception e)
            {
                return "İşlem Hatası: " + " " + e.Message;
            }
            
        }

        public List<EducationalApplyPreviewDto> GetAll()
        {
            var model = _educationalApplyRepository.GetAll();
            var dtos = CustomMapper.ToEducationalApplyPreviewDtos(model);
            return dtos;
        }

        public EducationalApplyDetailDto GetById(Guid id)
        {
            var model = _educationalApplyRepository.GetById(id);
            var dto = CustomMapper.ToEducationalApplyDetailDto(model);
            return dto;
        }

        public void DeleteById(Guid id)
        {
            _educationalApplyRepository.Delete(id);
        }

        public void UpdateById(Guid id)
        {
            _educationalApplyRepository.Update(id);
        }

        public List<EducationalApplyPreviewDto> GetAllForApproval()
        {
            var model = _educationalApplyRepository.GetAll();
            var dtos = CustomMapper.ToEducationalApplyPreviewDtos(model);
            return dtos;
        }
    }
}