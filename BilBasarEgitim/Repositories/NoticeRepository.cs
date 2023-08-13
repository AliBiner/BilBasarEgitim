using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Entities;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories
{
    public class NoticeRepository
    {

        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());
        public void Add(Notice entity)
        {
            _connection.Open();
            string query = "insert into notices (id,imageUrl,description,header,createDate,adminId,noticeCheck) values (@id,@imageUrl,@description,@header,@createDate,@adminId,@noticeCheck)";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("id", Guid.NewGuid());
                command.Parameters.AddWithValue("imageUrl", entity.ImageUrl);
                command.Parameters.AddWithValue("description", entity.Description);
                command.Parameters.AddWithValue("createDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("adminId", entity.AdminId);
                command.Parameters.AddWithValue("noticeCheck", entity.Check);
                command.Parameters.AddWithValue("header", entity.Header);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
        public void UpdateRelease(Notice entitiy)
        {
            _connection.Open();
            string query = "update notices set updateDate=@updateDate, noticeCheck=@noticeCheck where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", entitiy.Id);
                command.Parameters.AddWithValue("updateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("noticeCheck", entitiy.Check);
                command.ExecuteNonQuery();

            }
            _connection.Close();
        }
        public void Update(Notice entitiy)
        {
            _connection.Open();
            string query = "update notices set updateDate=@updateDate,imageUrl = @imageUrl,description=@description,header = @header  where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", entitiy.Id);
                command.Parameters.AddWithValue("imageUrl", entitiy.ImageUrl);
                command.Parameters.AddWithValue("description", entitiy.Description);
                command.Parameters.AddWithValue("header", entitiy.Header);
                command.Parameters.AddWithValue("updateDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();

            }
            _connection.Close();
        }
        public void Delete(Guid id)
        {
            _connection.Open();
            string query = "update notices set deleteDate=@deleteDate,noticeCheck=false where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("deleteDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
        public Notice GetById(Guid id)
        {
            _connection.Open();
            string query = "select * from notices where Id=@Id";
            Notice notice = new Notice();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        notice.Id = reader.GetGuid("Id");
                        notice.ImageUrl = reader.GetString("ImageUrl");
                        notice.Description = reader.GetString("Description");
                        notice.Header = reader.GetString("header");
                        notice.CreateDate = reader.GetDateTime("CreateDate");
                        notice.UpdateDate = reader.GetDateTime("UpdateDate");
                        notice.Check = reader.GetBoolean("noticeCheck");
                        notice.AdminId = reader.GetGuid("AdminId");
                    }
                }
            }
            _connection.Close();
            return notice;
        }
        public List<Notice> GetAllNotDelete()
        {
            _connection.Open();
            string query = "select * from notices where deleteDate is null";
            List<Notice> notices = new List<Notice>();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Notice notice = new Notice()
                        {
                            Id = reader.GetGuid("Id"),
                            ImageUrl = reader.GetString("imageUrl"),
                            Description = reader.GetString("description"),
                            Header = reader.GetString("header"),
                            Check = reader.GetBoolean("noticeCheck"),
                            AdminId = reader.GetGuid("adminId"),
                            CreateDate = reader.GetDateTime("createDate"),
                            UpdateDate = reader.GetDateTime("updateDate")
                        };

                        notices.Add(notice);
                    }
                }
            }
            _connection.Close();
            return notices;
        }
        public List<Notice> GetAllForUser()
        {
            _connection.Open();
            string query = "select imageUrl,description,header from notices where deleteDate is null and noticeCheck = true";
            List<Notice> notices = new List<Notice>();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Notice notice = new Notice()
                        {
                            ImageUrl = reader.GetString("imageUrl"),
                            Description = reader.GetString("description"),
                            Header = reader.GetString("header")
                        };
                        notices.Add(notice);
                    }
                }
            }
            _connection.Close();
            return notices;
        }
    }
}
