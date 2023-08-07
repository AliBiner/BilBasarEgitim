using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Repositories.JobApplyRepository;

namespace BilBasarEgitim.Services
{
    public class JobApplyService
    {
        private readonly JobApplyRepository _jobApplyRepository = new JobApplyRepository();

        public string AddJobAppealWithCv(JopApplyAddDto dto,HttpPostedFileBase cv)
        {
            try
            {
                var cvurl = CustomMethod.DocumentUpload(cv);
                var model = CustomMapper.JobAppealAddDtoTo(dto);
                model.CvUrl = cvurl;
                _jobApplyRepository.Add(model);
                return "İşlem Başarılı";
            }
            catch (Exception e)
            {
                return "İşlem Hatası: " + " " +e.Message;
            }
           
        }

        public List<JobApplyPreviewDto> GetAllForPreview()
        {
           
                var model = _jobApplyRepository.GetAll();
                var dtos = CustomMapper.ToJobAppealPreviewDtos(model);
                return dtos;
            
           

        }

        public JobApplyDetailDto GetById(Guid id)
        {
            
            var model = _jobApplyRepository.GetById(id);
            var dto = CustomMapper.ToJobAppealDetailDto(model);
            return dto;


        }

        public void DeleteById(Guid id)
        {
            _jobApplyRepository.Delete(id);
        }
        public void UpdateById(Guid id)
        {
            _jobApplyRepository.Update(id);
        }
    }
}