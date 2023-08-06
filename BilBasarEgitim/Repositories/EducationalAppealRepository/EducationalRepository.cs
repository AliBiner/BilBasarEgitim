using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Entities;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories.EducationalAppealRepository
{
    public class EducationalRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());

        void Add(EducationalAppeal entity)
        {
            _connection.Open();
            string insertQuery = @"INSERT INTO EducationalAppeals
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
    }
}