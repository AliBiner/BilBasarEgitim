using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Models.Dtos;

namespace BilBasarEgitim.Services
{
    public class HomeService
    {
        public readonly SliderService SliderService = new SliderService();
        public readonly NoticeService NoticeService = new NoticeService();
        private readonly NewsService newsService = new NewsService();
        private readonly AcademicStaffService academicStaffService = new AcademicStaffService();

        public HomeCombineDto HomeDatas()
        {
            var homeDatas = new HomeCombineDto();
            homeDatas.SliderForUserDtos = SliderService.GetAllOnlyUrl();
            homeDatas.NoticeForUserDtos = NoticeService.GetAllOnlyUrl();
            homeDatas.NewsForUserDtos = newsService.GetAllOnlyUrl();
            homeDatas.AcademicStaffForUserDtos = academicStaffService.GetAllForUser();
            return homeDatas;
        }
    }
}