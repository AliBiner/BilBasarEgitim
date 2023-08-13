using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Models.Dtos.AcademicStaff;
using BilBasarEgitim.Models.News;

namespace BilBasarEgitim.Models.Dtos
{
    public class HomeCombineDto
    {
        public HomeCombineDto()
        {
            SliderForUserDtos = new List<SliderForUserDto>();
            NoticeForUserDtos = new List<NoticeForUserDto>();
            NewsForUserDtos = new List<NewsForUserDto>();
            AcademicStaffForUserDtos = new List<AcademicStaffForUserDto>();
        }
        public List<SliderForUserDto> SliderForUserDtos { get; set; }
        public List<NoticeForUserDto> NoticeForUserDtos { get; set; }
        public List<NewsForUserDto> NewsForUserDtos { get; set; }
        public List<AcademicStaffForUserDto> AcademicStaffForUserDtos { get; set; }
    }
}