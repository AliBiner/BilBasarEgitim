using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Entities;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories
{
    public class AcademicStaffRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());

        public void Add(AcademicStaff entity)
        {
            _connection.Open();
            string query =
                "insert into academicStaffs (Id,imageUrl,name,surname,educatorField,facebookUrl,twitterUrl,instagramUrl,createDate,academicStaffCheck,adminId) values (@Id,@imageUrl,@name,@surname,@educatorField,@facebookUrl,@twitterUrl,@instagramUrl,@createDate,@academicStaffCheck,@adminId)";
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", Guid.NewGuid());
                command.Parameters.AddWithValue("imageUrl", entity.ImageUrl);
                command.Parameters.AddWithValue("name", entity.Name);
                command.Parameters.AddWithValue("surname", entity.SurName);
                command.Parameters.AddWithValue("educatorField", entity.EducatorField);
                command.Parameters.AddWithValue("facebookUrl", entity.FaceBookUrl);
                command.Parameters.AddWithValue("twitterUrl", entity.TwitterUrl);
                command.Parameters.AddWithValue("instagramUrl", entity.InstagramUrl);
                command.Parameters.AddWithValue("createDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("academicStaffCheck", entity.Check);
                command.Parameters.AddWithValue("adminId", entity.AdminId);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public void Delete(Guid Id)
        {
            _connection.Open();
            string query = "update academicStaffs set deleteDate = @deleteDate,academicStaffCheck = false where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", Id);
                command.Parameters.AddWithValue("deleteDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public void Update(AcademicStaff entity)
        {
            _connection.Open();
            string query =
                "update academicStaffs  " +
                "set imageUrl=@imageUrl,name=@name,surname=@surname,educatorField=@educatorField,facebookUrl=@facebookUrl," +"twitterUrl=@twitterUrl,instagramUrl=@instagramUrl where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", entity.Id);
                command.Parameters.AddWithValue("imageUrl", entity.ImageUrl);
                command.Parameters.AddWithValue("name", entity.Name);
                command.Parameters.AddWithValue("surname", entity.SurName);
                command.Parameters.AddWithValue("educatorField", entity.EducatorField);
                command.Parameters.AddWithValue("facebookUrl", entity.FaceBookUrl);
                command.Parameters.AddWithValue("twitterUrl", entity.TwitterUrl);
                command.Parameters.AddWithValue("instagramUrl", entity.InstagramUrl);
                command.Parameters.AddWithValue("adminId", entity.AdminId);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
        public void UpdateRelease(AcademicStaff entitiy)
        {
            _connection.Open();
            string query = "update academicStaffs set updateDate=@updateDate, academicStaffCheck=@academicStaffCheck where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", entitiy.Id);
                command.Parameters.AddWithValue("updateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("academicStaffCheck", entitiy.Check);
                command.ExecuteNonQuery();

            }
            _connection.Close();
        }
        public List<AcademicStaff> GetAll()
        {
            _connection.Open();
            string query = "select id,name,surname,academicStaffCheck,educatorField,createDate from academicStaffs where deleteDate is null";
            List<AcademicStaff> academics = new List<AcademicStaff>();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AcademicStaff academic = new AcademicStaff()
                        {
                            Id = reader.GetGuid("Id"),
                            Name = reader.GetString("name"),
                            SurName = reader.GetString("surname"),
                            Check = reader.GetBoolean("academicStaffCheck"),
                            EducatorField = reader.GetString("educatorField"),
                            CreateDate = reader.GetDateTime("createDate")
                        };
                        academics.Add(academic);
                    }
                    
                }
            }
            _connection.Close();
            return academics;
        }

        public List<AcademicStaff> GetAllForUser()
        {
            _connection.Open();
            string query = "select name,surname,imageUrl,facebookUrl,twitterUrl,instagramUrl from academicStaffs where deleteDate is null and academicStaffCheck = true";
            List<AcademicStaff> academics = new List<AcademicStaff>();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AcademicStaff academic = new AcademicStaff()
                        {
                           
                            Name = reader.GetString("name"),
                            SurName = reader.GetString("surname"),
                            ImageUrl = reader.GetString("imageUrl"),
                            FaceBookUrl = reader.GetString("facebookUrl"),
                            TwitterUrl = reader.GetString("twitterUrl"),
                            InstagramUrl = reader.GetString("instagramUrl"),

                        };
                        academics.Add(academic);
                    }
                   
                }
            }
            _connection.Close();
            return academics;
        }

        public AcademicStaff GetById(Guid id)
        {
            _connection.Open();
            string query =
                "select name,surname,imageUrl,educatorField,facebookUrl,twitterUrl,instagramUrl,createdate,updateDate from academicStaffs where Id=@Id";
            AcademicStaff academic = new AcademicStaff();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        academic.Id = id;
                        academic.Name = reader.GetString("name");
                        academic.SurName = reader.GetString("surname");
                        academic.ImageUrl = reader.GetString("imageUrl");
                        academic.FaceBookUrl = reader.GetString("facebookUrl");
                        academic.TwitterUrl = reader.GetString("twitterUrl");
                        academic.InstagramUrl = reader.GetString("instagramUrl");
                        academic.EducatorField = reader.GetString("educatorField");
                        academic.CreateDate = reader.GetDateTime("createdate");
                        academic.UpdateDate = reader.GetDateTime("updateDate");
                        
                    }
                   

                }
            }
            _connection.Close();
            return academic;
        }
    }
}