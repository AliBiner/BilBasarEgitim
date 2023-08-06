using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Repositories.JobAppealRepository;

namespace BilBasarEgitim.Services
{
    public class JobAppealService
    {
        private readonly JobAppealRepository _jobAppealRepository = new JobAppealRepository();

        public string AddJobAppealWithCv(JopAppealAddDto dto,HttpPostedFileBase cv)
        {
            try
            {
                var cvurl = CustomMethod.DocumentUpload(cv);
                var model = CustomMapper.JobAppealAddDtoTo(dto);
                model.CvUrl = cvurl;
                _jobAppealRepository.Add(model);
                return "İşlem Başarılı";
            }
            catch (Exception e)
            {
                return "İşlem Hatası: " + " " +e.Message;
            }
           
        }
    }
}