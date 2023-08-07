using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Entities;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories.JobApplyRepository
{
    public class JobApplyRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());

        public void Add(JobApply entity)
        {
            _connection.Open();
            string insertQuery = @"INSERT INTO jobapplies
                                  (Id, CreateDate, UpdateDate, DeleteDate, JobAppealCheck, FullName, Email, Phone, BirthDate, JobRole, Gender, MartialStatus, Nationality, GraduateSchool, JobExperience,CvUrl)
                                  VALUES
                                  (@Id, @CreateDate, @UpdateDate, @DeleteDate, @JobAppealCheck, @FullName, @Email, @Phone, @BirthDate, @JobRole, @Gender, @MartialStatus, @Nationality, @GraduateSchool, @JobExperience,@CvUrl)";

            using (MySqlCommand command = new MySqlCommand(insertQuery, _connection))
            {
                command.Parameters.AddWithValue("@Id", Guid.NewGuid()); // Generate a new GUID
                command.Parameters.AddWithValue("@CreateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("@UpdateDate", DBNull.Value);
                command.Parameters.AddWithValue("@DeleteDate", DBNull.Value);
                command.Parameters.AddWithValue("@JobAppealCheck", true);
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
                command.Parameters.AddWithValue("@CvUrl", entity.CvUrl);
                
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public List<JobApply> GetAll()
        {
            _connection.Open();
            string query = "Select * from jobapplies where DeleteDate is Null and UpdateDate is null";
            List<JobApply> jobAppeals = new List<JobApply>();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JobApply jobApply = new JobApply()
                        {
                            Id = reader.GetGuid("Id"),
                            FullName = reader.GetString("FullName"),
                            BirthDate = reader.GetString("BirthDate"),
                            JobRole = reader.GetString("JobRole"),
                            Gender = reader.GetString("Gender"),
                            Nationality = reader.GetString("Nationality"),
                            CreateDate = reader.GetDateTime("CreateDate")
                        };
                        jobAppeals.Add(jobApply);
                    }
                }
            }
            _connection.Close();
            return jobAppeals;
        }

        public JobApply GetById(Guid id)
        {
            _connection.Open();
            string query = "select * from jobapplies where Id=@Id and DeleteDate is null";
            JobApply jobApply = new JobApply();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        jobApply.Id = reader.GetGuid("Id");
                        jobApply.FullName = reader.GetString("FullName");
                        jobApply.Email = reader.GetString("Email");
                        jobApply.Phone = reader.GetString("Phone");
                        jobApply.BirthDate = reader.GetString("BirthDate");
                        jobApply.JobRole = reader.GetString("JobRole");
                        jobApply.Gender = reader.GetString("Gender");
                        jobApply.Nationality = reader.GetString("Nationality");
                        jobApply.MartialStatus = reader.GetString("MartialStatus");
                        jobApply.GraduateSchool = reader.GetString("GraduateSchool");
                        jobApply.JobExperience = reader.GetString("JobExperience");
                        jobApply.CvUrl = reader.GetString("CvUrl");
                        jobApply.CreateDate = reader.GetDateTime("CreateDate");
                    }
                }
            }
            _connection.Close();
            return jobApply;
        }

        public void Delete(Guid id)
        {
            _connection.Open();
            string query = "update jobapplies set DeleteDate = @DeleteDate, JobAppealCheck=@JobAppealCheck where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("DeleteDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("JobAppealCheck", false);
                command.ExecuteNonQuery();

            }
            _connection.Close();
        }

        public void Update(Guid Id)
        {
            _connection.Open();
            string query = "update jobapplies set UpdateDate = @UpdateDate where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", Id);
                command.Parameters.AddWithValue("UpdateDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}