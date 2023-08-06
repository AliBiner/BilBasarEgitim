using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Entities;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories.JobAppealRepository
{
    public class JobAppealRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());

        public void Add(JobAppeal entity)
        {
            _connection.Open();
            string insertQuery = @"INSERT INTO JobAppeals
                                  (Id, CreateDate, UpdateDate, DeleteDate, EducatioanlAppealCheck, FullName, Email, Phone, BirthDate, JobRole, Gender, MartialStatus, Nationality, GraduateSchool, JobExperience)
                                  VALUES
                                  (@Id, @CreateDate, @UpdateDate, @DeleteDate, @EducatioanlAppealCheck, @FullName, @Email, @Phone, @BirthDate, @JobRole, @Gender, @MartialStatus, @Nationality, @GraduateSchool, @JobExperience)";

            using (MySqlCommand command = new MySqlCommand(insertQuery, _connection))
            {
                command.Parameters.AddWithValue("@Id", Guid.NewGuid()); // Generate a new GUID
                command.Parameters.AddWithValue("@CreateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("@UpdateDate", DBNull.Value);
                command.Parameters.AddWithValue("@DeleteDate", DBNull.Value);
                command.Parameters.AddWithValue("@EducatioanlAppealCheck", true);
                command.Parameters.AddWithValue("@FullName", entity.FullName);
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@Phone", entity.Phone);
                command.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
                command.Parameters.AddWithValue("@JobRole", entity.JobRole);
                command.Parameters.AddWithValue("@Gender", entity.Gender);
                command.Parameters.AddWithValue("@MartialStatus", entity.MartialStatus);
                command.Parameters.AddWithValue("@Nationality", entity.Nationality);
                command.Parameters.AddWithValue("@GraduateSchool", entity.GraduateSchool);
                command.Parameters.AddWithValue("@JobExperience", entity.JobExperience);
                
                command.ExecuteNonQuery();
            }
        }
    }
}