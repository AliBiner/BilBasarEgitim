using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Repositories.JobAppealRepository;

namespace BilBasarEgitim.Services
{
    public class JobAppealService
    {
        private readonly JobAppealRepository _jobAppealRepository = new JobAppealRepository();

        public string AddJobAppealWithCv(JopAppealAddDto dto,HttpPostedFileBase cv)
        {
            return "";
        }
    }
}