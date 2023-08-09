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
                var cvurl = CustomMethod.CvUpload(cv);
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
            try
            {
                var model = _jobApplyRepository.GetAll();
                var dtos = CustomMapper.ToJobAppealPreviewDtos(model);
                return dtos;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
               
           

        }

        public JobApplyDetailDto GetById(Guid id)
        {
            try
            {
                var model = _jobApplyRepository.GetById(id);
                var dto = CustomMapper.ToJobAppealDetailDto(model);
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
            var model = GetById(id);
            CustomMethod.CvDelete(model.CvUrl);
            _jobApplyRepository.Delete(id);
            
        }
        public void UpdateById(Guid id)
        {
            _jobApplyRepository.Update(id);
        }

        public List<JobApplyPreviewDto> GetAllForApproval()
        {
            try
            {
                var model = _jobApplyRepository.GetAllApproval();
                var dtos = CustomMapper.ToJobAppealPreviewDtos(model);
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