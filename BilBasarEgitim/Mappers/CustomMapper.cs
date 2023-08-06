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
        public static JobAppeal JobAppealAddDtoTo(JopAppealAddDto dto)
        {
            return new JobAppeal()
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
    }
}