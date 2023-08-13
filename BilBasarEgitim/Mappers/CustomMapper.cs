using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Dtos.AcademicStaff;
using BilBasarEgitim.Models.Dtos.News;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Models.News;

namespace BilBasarEgitim.Mappers
{
    public class CustomMapper
    {
        //JopApply
        public static JobApply JobAppealAddDtoTo(JopApplyAddDto dto)
        {
            return new JobApply()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                BirthDate = dto.BirthDate,
                JobRole = dto.JobRole,
                Gender = dto.Gender,
                MartialStatus = dto.MartialStatus,
                Nationality = dto.Nationality,
                GraduateSchool = dto.GraduateSchool,
                JobExperience = dto.JobExperience
            };
        }
        public static List<JobApplyPreviewDto> ToJobAppealPreviewDtos(List<JobApply> list)
        {
            List<JobApplyPreviewDto> dtos = new List<JobApplyPreviewDto>();
            string ageFormat = "yyyy-MM-dd";

            foreach (var i in list)
            {
                JobApplyPreviewDto jobApplyDto = new JobApplyPreviewDto()
                {
                    Id = i.Id,
                    FullName = i.FullName,
                    JobRole = i.JobRole,
                    Age = DateTime.Today.Year - DateTime.ParseExact(i.BirthDate, ageFormat, System.Globalization.CultureInfo.InvariantCulture).Year,
                    CreateDate = i.CreateDate.ToString("dd/MM/yyyy HH:mm")
                };
                dtos.Add(jobApplyDto);
            }

            return dtos;
        }
        public static JobApplyDetailDto ToJobAppealDetailDto(JobApply entity)
        {
            string ageFormat = "yyyy-MM-dd";
            return new JobApplyDetailDto()
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Phone = entity.Phone,
                Age = DateTime.Today.Year - DateTime.ParseExact(entity.BirthDate, ageFormat, System.Globalization.CultureInfo.InvariantCulture).Year,
                JobRole = entity.JobRole,
                Gender = entity.Gender,
                MartialStatus = entity.MartialStatus,
                Nationality = entity.Nationality,
                GraduateSchool = entity.GraduateSchool,
                JobExperience = entity.JobExperience,
                CvUrl = entity.CvUrl,
                CreateDate = entity.CreateDate.ToString("dd/MM/yyyy HH:mm")
            };
        }
       
        //Educational
        public static EducationalApply EducationalAppealAddDtoTo(EducationalApplyAddDto dto)
        {
            return new EducationalApply()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                EducationalField = dto.EducationalField,
                ParentName = dto.ParentName,
                ParentPhone = dto.ParentPhone,
                SchoolName = dto.SchoolName,
                Grade = dto.Grade
            };
        }
        public static List<EducationalApplyPreviewDto> ToEducationalApplyPreviewDtos(List<EducationalApply> list)
        {
            List<EducationalApplyPreviewDto> dtos = new List<EducationalApplyPreviewDto>();
            foreach (var i in list)
            {
                EducationalApplyPreviewDto dto = new EducationalApplyPreviewDto()
                {
                    Id = i.Id,
                    FullName = i.FullName,
                    EducationalField = i.EducationalField,
                    Grade = i.Grade,
                    SchoolName = i.SchoolName,
                    CreateDate = i.CreateDate.ToString("dd/MM/yyyy HH:mm")
                };
                dtos.Add(dto);
            }

            return dtos;
        }
        public static EducationalApplyDetailDto ToEducationalApplyDetailDto(EducationalApply entity)
        {
            return new EducationalApplyDetailDto()
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Phone = entity.Phone,
                EducationalField = entity.EducationalField,
                ParentName = entity.ParentName,
                ParentPhone = entity.ParentPhone,
                SchoolName = entity.SchoolName,
                Grade = entity.Grade,
                CreateDate = entity.CreateDate.ToString("dd/MM/yyyy HH:mm")
            };
        }
       
        //Admin
        public static Admin AdminRegisterDtoto(AdminRegisterDto dto)
        {
            return new Admin()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password
            };
        }
        public static Admin AdminProfileUpdateDtoTo(AdminProfileUpdateDto dto)
        {
            return new Admin()
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Email = dto.Email
            };
        }

        public static Admin AdminChangePasswordDtoTo(AdminChangePasswordDto dto)
        {
            return new Admin()
            {
                Id = dto.Id,
                Password = dto.NewPassword
            };
        }


        //Document
        public static Document DocumentAddDtoTo(DocumentAddDto dto)
        {
            return new Document()
            {
                Description = dto.Description,
                AdminId = dto.AdminId
            };
        }
        public static List<DocumentPreviewDto> ToDocumentPreviewDtos(List<Document> list)
        {
            List<DocumentPreviewDto> dtos = new List<DocumentPreviewDto>();
            foreach (var i in list)
            {
                DocumentPreviewDto dto = new DocumentPreviewDto()
                {
                    Id = i.Id,
                    Description = i.Description,
                    DocumentUrl = i.DocumentUrl,
                    CreateDate = i.CreateDate.ToString("dd/MM/yyyy HH:mm")
                };
                dtos.Add(dto);
            }

            return dtos;
        }
        
        
        //SendEmail
        public static SendEmailDto ToSendEmailDto(SendEmail entity)
        {
            return new SendEmailDto()
            {
                Id = entity.Id,
                Email = entity.Email,
                Update = entity.UpdateDate.ToString("dd/MM/yyyy HH:mm")
            };
        }

        //Slider
        public static Slider SliderAddDtoTo(SliderAddDto dto)
        {
            return new Slider()
            {
                AdminId = dto.AdminId,
                Check = dto.Check
            };
        }
        public static List<SliderForAdminDto> ToSlidersDto(List<Slider> entity)
        {
            List<SliderForAdminDto> sliders = new List<SliderForAdminDto>();
            foreach (var i in entity)
            {
                var slider = new SliderForAdminDto();
                if (i.Check == true)
                {

                    slider.Id = i.Id;
                    slider.CreateDate = i.CreateDate.ToString("dd/MM/yyyy HH:mm");
                    slider.SliderUrl = i.ImageUrl;
                    slider.Check = "Yayında";

                }
                else
                {
                    slider.Id = i.Id;
                    slider.CreateDate = i.CreateDate.ToString("dd/MM/yyyy HH:mm");
                    slider.SliderUrl = i.ImageUrl;
                    slider.Check = "Yayında Değil";

                }
               sliders.Add(slider);
            }

            return sliders;
        }
        public static List<SliderForUserDto> ToSliderForUserDto(List<Slider> entity)
        {
            List<SliderForUserDto> sliders = new List<SliderForUserDto>();
            foreach (var VARIABLE in entity)
            {
                var slider = new SliderForUserDto()
                {
                    SliderUrl = VARIABLE.ImageUrl
                };
                sliders.Add(slider);
            }

            return sliders;

        }

        //Notice
        public static Notice NoticeAddDtoTo(NoticeAddDto dto)
        {
            return new Notice()
            {
                AdminId = dto.AdminId,
                Description = dto.Description,
                Header = dto.Header,
                Check = dto.Check,
            };
        }
        public static List<NoticeForAdminDto> ToNoticesDto(List<Notice> entity)
        {
            List<NoticeForAdminDto> notices = new List<NoticeForAdminDto>();
            foreach (var i in entity)
            {
                var notice = new NoticeForAdminDto();
                if (i.Check == true)
                {

                    notice.Id = i.Id;
                    notice.Description = i.Description;
                    notice.Header = i.Header;
                    notice.CreateDate = i.CreateDate.ToString("dd/MM/yyyy HH:mm");
                    notice.NoticeUrl = i.ImageUrl;
                    notice.Check = "Yayında";

                }
                else
                {
                    notice.Id = i.Id;
                    notice.Description = i.Description;
                    notice.CreateDate = i.CreateDate.ToString("dd/MM/yyyy HH:mm");
                    notice.NoticeUrl = i.ImageUrl;
                    notice.Check = "Yayında Değil";

                }
                notices.Add(notice);
            }

            return notices;
        }
        public static List<NoticeForUserDto> ToNoticeForUserDto(List<Notice> entity)
        {
            List<NoticeForUserDto> notices = new List<NoticeForUserDto>();
            foreach (var VARIABLE in entity)
            {
                var notice = new NoticeForUserDto()
                {
                     NoticeUrl= VARIABLE.ImageUrl,
                     Description = VARIABLE.Description,
                     Header = VARIABLE.Header

                };
                notices.Add(notice);
            }

            return notices;

        }
        public static Notice NoticeUpdateDtoTo(NoticeUpdateDto dto)
        {
            return new Notice()
            {
                Id = dto.Id,
                Check = dto.Check,
                ImageUrl = dto.NoticeUrl,
                Description = dto.Description,
                Header = dto.Header
            };
        }
        public static NoticeUpdateDto ToNoticeUpdateDto(Notice entity)
        {
            return new NoticeUpdateDto()
            {
                Id = entity.Id,
                Check = entity.Check,
                NoticeUrl = entity.ImageUrl,
                Description = entity.Description,
                Header = entity.Header
            };
        }
        public static NoticeForAdminDto ToNoticeForAdminDto(Notice entity)
        {
            
                var notice = new NoticeForAdminDto();
                if (entity.Check == true)
                {

                    notice.Id = entity.Id;
                    notice.CreateDate = entity.CreateDate.ToString("dd/MM/yyyy HH:mm");
                    notice.NoticeUrl = entity.ImageUrl;
                    notice.Check = "Yayında";
                    notice.Description = entity.Description;
                    notice.Header = entity.Header;

                }
                else
                {
                    notice.Id = entity.Id;
                    notice.CreateDate = entity.CreateDate.ToString("dd/MM/yyyy HH:mm");
                    notice.NoticeUrl = entity.ImageUrl;
                    notice.Check = "Yayında Değil";
                    notice.Description = entity.Description;
                    notice.Header = entity.Header;

                }
            
                return notice;
        }

        //News
        public static News NewsAddDtoTo(NewsAddDto dto)
        {
            return new News()
            {
                AdminId = dto.AdminId,
                Description = dto.Description,
                Check = dto.Check,
            };
        }
        public static List<NewsForAdminDto> ToNewsDto(List<News> entity)
        {
            List<NewsForAdminDto> newsList = new List<NewsForAdminDto>();
            foreach (var i in entity)
            {
                var news = new NewsForAdminDto();
                if (i.Check == true)
                {

                    news.Id = i.Id;
                    news.Description = i.Description;
                    news.CreateDate = i.CreateDate.ToString("dd/MM/yyyy HH:mm");
                    news.NewsUrl = i.ImageUrl;
                    news.Check = "Yayında";

                }
                else
                {
                    news.Id = i.Id;
                    news.Description = i.Description;
                    news.CreateDate = i.CreateDate.ToString("dd/MM/yyyy HH:mm");
                    news.NewsUrl = i.ImageUrl;
                    news.Check = "Yayında Değil";

                }
                newsList.Add(news);
            }

            return newsList;
        }
        public static List<NewsForUserDto> ToNewsForUserDto(List<News> entity)
        {
            List<NewsForUserDto> newsList = new List<NewsForUserDto>();
            foreach (var VARIABLE in entity)
            {
                var news = new NewsForUserDto()
                {
                    NewsUrl = VARIABLE.ImageUrl,
                    Description = VARIABLE.Description,
                    CreateDate = VARIABLE.CreateDate.ToString("dd/MM/yyyy")
                    

                };
                newsList.Add(news);
            }

            return newsList;

        }
        public static News NewsUpdateDtoTo(NewsUpdateDto dto)
        {
            return new News()
            {
                Id = dto.Id,
                Check = dto.Check,
                ImageUrl = dto.NewsUrl,
                Description = dto.Description,
            };
        }
        public static NewsUpdateDto ToNewsUpdateDto(News entity)
        {
            return new NewsUpdateDto()
            {
                Id = entity.Id,
                Check = entity.Check,
                NewsUrl = entity.ImageUrl,
                Description = entity.Description,
            };
        }
        public static NewsForAdminDto ToNewsForAdminDto(News entity)
        {

            var news = new NewsForAdminDto();
            if (entity.Check == true)
            {

                news.Id = entity.Id;
                news.CreateDate = entity.CreateDate.ToString("dd/MM/yyyy HH:mm");
                news.NewsUrl = entity.ImageUrl;
                news.Check = "Yayında";
                news.Description = entity.Description;

            }
            else
            {
                news.Id = entity.Id;
                news.CreateDate = entity.CreateDate.ToString("dd/MM/yyyy HH:mm");
                news.NewsUrl = entity.ImageUrl;
                news.Check = "Yayında Değil";
                news.Description = entity.Description;
                

            }

            return news;
        }

        //Academic Staff

        public static AcademicStaff AcademicStaffAddDtoTo(AcademicStaffAddDto dto)
        {
            return new AcademicStaff()
            {
                Name = dto.Name,
                SurName = dto.SurName,
                EducatorField = dto.EducatorField,
                FaceBookUrl = dto.FacebookUrl==null ? "Boş" : dto.FacebookUrl,
                TwitterUrl = dto.TwitterUrl == null ? "Boş" : dto.TwitterUrl,
                InstagramUrl = dto.InstagramUrl == null ? "Boş" : dto.InstagramUrl,
                AdminId = dto.AdminId,
                Check = dto.Check
            };
        }

        public static List<AcademicStaffPreviewForAdminDto> ToAcademicStaffPreviewForAdminDtos(
            List<AcademicStaff> entity)
        {
            List<AcademicStaffPreviewForAdminDto> academics = new List<AcademicStaffPreviewForAdminDto>();
            foreach (var staff in entity)
            {
                AcademicStaffPreviewForAdminDto academic = new AcademicStaffPreviewForAdminDto();
                if (staff.Check== true)
                {

                    academic.Id = staff.Id;
                    academic.FullName = staff.Name + " " + staff.SurName;
                    academic.EdicatorField = staff.EducatorField;
                    academic.Check = "Görünüyor";
                    academic.CreateDate = staff.CreateDate.ToString("dd/MM/yyyy HH:mm");

                }
                else
                {

                    academic.Id = staff.Id;
                    academic.FullName = staff.Name + " " + staff.SurName;
                    academic.EdicatorField = staff.EducatorField;
                    academic.Check = "Gizli";
                    academic.CreateDate = staff.CreateDate.ToString("dd/MM/yyyy HH:mm");

                }
                academics.Add(academic);
            }

            return academics;
        }

        public static AcademicStaff AcademicStaffUpdateDtoTo(AcademicStaffUpdateDto dto)
        {
            return new AcademicStaff()
            {
                Id = dto.Id,
                ImageUrl = dto.ImageUrl,
                Name = dto.Name,
                SurName = dto.SurName,
                EducatorField = dto.EducatorField,
                FaceBookUrl = dto.FaceBookUrl,
                TwitterUrl = dto.TwitterUrl,
                InstagramUrl = dto.InstagramUrl,

            };
        }

        public static AcademicStaffUpdateDto ToAcademicStaffUpdateDto(AcademicStaff entity)
        {
            return new AcademicStaffUpdateDto()
            {
                Id = entity.Id,
                ImageUrl = entity.ImageUrl,
                Name = entity.Name,
                SurName = entity.SurName,
                EducatorField = entity.EducatorField,
                FaceBookUrl = entity.FaceBookUrl,
                TwitterUrl = entity.TwitterUrl,
                InstagramUrl = entity.InstagramUrl,

            };
        }

        public static List<AcademicStaffForUserDto> ToAcademicStaffForUserDtos(List<AcademicStaff> entity)
        {
            var academics = new List<AcademicStaffForUserDto>();
            foreach (var item in entity)
            {
                var academic = new AcademicStaffForUserDto()
                {
                    FullName = item.Name + " " +item.SurName,
                    ImageUrl = item.ImageUrl,
                    FacebookUrl = item.FaceBookUrl,
                    TwitterUrl = item.TwitterUrl,
                    InstagramUrl = item.InstagramUrl
                };
                academics.Add(academic);
            }

            return academics;
        }
    }
}