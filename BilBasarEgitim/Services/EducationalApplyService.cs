using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
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
                SendEmailService sendEmail = new SendEmailService();
                var result = sendEmail.SendEmailForEducational(dto);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "İşlem Hatası"; 
            }
            
        }

        public List<EducationalApplyPreviewDto> GetAll()
        {
            try
            {
                var model = _educationalApplyRepository.GetAll();
                var dtos = CustomMapper.ToEducationalApplyPreviewDtos(model);
                return dtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
           
        }

        public EducationalApplyDetailDto GetById(Guid id)
        {
            try
            {
                var model = _educationalApplyRepository.GetById(id);
                var dto = CustomMapper.ToEducationalApplyDetailDto(model);
                return dto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
           
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
            try
            {
                var model = _educationalApplyRepository.GetAllForApproval();
                var dtos = CustomMapper.ToEducationalApplyPreviewDtos(model);
                return dtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
           
        }
    }
}