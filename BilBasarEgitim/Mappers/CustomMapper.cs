using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Entities;

namespace BilBasarEgitim.Mappers
{
    public class CustomMapper
    {
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

        public static Admin AdminRegisterDtoto(AdminRegisterDto dto)
        {
            return new Admin()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password
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

        public static SendEmailDto ToSendEmailDto(SendEmail entity)
        {
            return new SendEmailDto()
            {
                Id = entity.Id,
                Email = entity.Email,
                Update = entity.UpdateDate.ToString("dd/MM/yyyy HH:mm")
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

        public static Slider SliderAddDtoTo(SliderAddDto dto)
        {
            return new Slider()
            {
                ImageUrl = dto.ImageUrl,
                AdminId = dto.AdminId,
                Check = dto.Check
            };
        }

    }
}