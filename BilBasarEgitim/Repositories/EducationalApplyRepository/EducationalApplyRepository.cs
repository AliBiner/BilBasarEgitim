using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Entities;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories.EducationalApplyRepository
{
    public class EducationalApplyRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());

        public void Add(EducationalApply entity)
        {
            _connection.Open();
            string insertQuery = @"INSERT INTO educationalapplies
                                  (Id, CreateDate, UpdateDate, DeleteDate, EducatioanlAppealCheck, FullName, Email, Phone, EducationalField, ParentName, ParentPhone, SchoolName, Grade)
                                  VALUES
                                  (@Id, @CreateDate, @UpdateDate, @DeleteDate, @EducatioanlAppealCheck, @FullName, @Email, @Phone, @EducationalField, @ParentName, @ParentPhone, @SchoolName, @Grade)";


            using (MySqlCommand command = new MySqlCommand(insertQuery, _connection))
            {
                command.Parameters.AddWithValue("@Id", Guid.NewGuid().ToString()); // Generate a new GUID
                command.Parameters.AddWithValue("@CreateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("@UpdateDate", DBNull.Value);
                command.Parameters.AddWithValue("@DeleteDate", DBNull.Value);
                command.Parameters.AddWithValue("@EducatioanlAppealCheck", true);
                command.Parameters.AddWithValue("@FullName", entity.FullName);
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@Phone", entity.Phone);
                command.Parameters.AddWithValue("@EducationalField", entity.EducationalField);
                command.Parameters.AddWithValue("@ParentName", entity.ParentName);
                command.Parameters.AddWithValue("@ParentPhone", entity.ParentPhone);
                command.Parameters.AddWithValue("@SchoolName", entity.SchoolName);
                command.Parameters.AddWithValue("@Grade", entity.Grade);

                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public List<EducationalApply> GetAll()
        {
            _connection.Open();
            string query = "select * from educationalapplies where DeleteDate is null and UpdateDate is null";
            List<EducationalApply> educationalApplies = new List<EducationalApply>();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EducationalApply educationalApply = new EducationalApply()
                        {
                            Id = reader.GetGuid("Id"),
                            FullName = reader.GetString("FullName"),
                            EducationalField = reader.GetString("EducationalField"),
                            Grade = reader.GetString("Grade"),
                            CreateDate = reader.GetDateTime("CreateDate"),
                            SchoolName = reader.GetString("SchoolName")
                        };
                        educationalApplies.Add(educationalApply);
                    }
                }
            }
            _connection.Close();
            return educationalApplies;

        }

        public EducationalApply GetById(Guid id)
        {
            _connection.Open();
            string query = "select * from educationalapplies where Id =@Id";
            EducationalApply educationalApply = new EducationalApply();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        educationalApply.Id = reader.GetGuid("Id");
                        educationalApply.FullName = reader.GetString("FullName");
                        educationalApply.Email = reader.GetString("Email");
                        educationalApply.Phone = reader.GetString("Phone");
                        educationalApply.EducationalField = reader.GetString("EducationalField");
                        educationalApply.ParentName = reader.GetString("ParentName");
                        educationalApply.ParentPhone = reader.GetString("ParentPhone");
                        educationalApply.SchoolName = reader.GetString("SchoolName");
                        educationalApply.Grade = reader.GetString("Grade");
                        educationalApply.CreateDate = reader.GetDateTime("CreateDate");

                    }
                }
            }
            _connection.Close();
            return educationalApply;
        }

        public void Delete(Guid id)
        {
            _connection.Open();
            string query = "update educationalapplies set DeleteDate = @DeleteDate,EducatioanlApplyCheck = false  where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("DeleteDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();
            }

            _connection.Close();
        }

        public void Update(Guid id)
        {
            _connection.Open();
            string query = "update educationalapplies set UpdateDate = @UpdateDate where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("UpdateDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}