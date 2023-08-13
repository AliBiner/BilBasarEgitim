using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Entities;

namespace BilBasarEgitim.Repositories
{
    public class NewsRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());
        public void Add(News entity)
        {
            _connection.Open();
            string query = "insert into news (id,imageUrl,description,createDate,adminId,newsCheck) values (@id,@imageUrl,@description,@createDate,@adminId,@newsCheck)";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("id", Guid.NewGuid());
                command.Parameters.AddWithValue("imageUrl", entity.ImageUrl);
                command.Parameters.AddWithValue("description", entity.Description);
                command.Parameters.AddWithValue("createDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("adminId", entity.AdminId);
                command.Parameters.AddWithValue("newsCheck", entity.Check);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
        public void UpdateRelease(News entitiy)
        {
            _connection.Open();
            string query = "update news set updateDate=@updateDate, newsCheck=@newsCheck where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", entitiy.Id);
                command.Parameters.AddWithValue("updateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("newsCheck", entitiy.Check);
                command.ExecuteNonQuery();

            }
            _connection.Close();
        }
        public void Update(News entitiy)
        {
            _connection.Open();
            string query = "update news set updateDate=@updateDate,imageUrl = @imageUrl,description=@description where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", entitiy.Id);
                command.Parameters.AddWithValue("imageUrl", entitiy.ImageUrl);
                command.Parameters.AddWithValue("description", entitiy.Description);
                command.Parameters.AddWithValue("updateDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();

            }
            _connection.Close();
        }
        public void Delete(Guid id)
        {
            _connection.Open();
            string query = "update news set deleteDate=@deleteDate,newsCheck=false where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("deleteDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
        public News GetById(Guid id)
        {
            _connection.Open();
            string query = "select * from news where Id=@Id";
            News news = new News();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        news.Id = reader.GetGuid("Id");
                        news.ImageUrl = reader.GetString("ImageUrl");
                        news.Description = reader.GetString("Description");
                        news.CreateDate = reader.GetDateTime("CreateDate");
                        news.UpdateDate = reader.GetDateTime("UpdateDate");
                        news.Check = reader.GetBoolean("newsCheck");
                        news.AdminId = reader.GetGuid("AdminId");
                    }
                }
            }
            _connection.Close();
            return news;
        }
        public List<News> GetAllNotDelete()
        {
            _connection.Open();
            string query = "select * from news where deleteDate is null";
            List<News> newsList = new List<News>();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        News news = new News()
                        {
                            Id = reader.GetGuid("Id"),
                            ImageUrl = reader.GetString("imageUrl"),
                            Description = reader.GetString("description"),
                            Check = reader.GetBoolean("newsCheck"),
                            AdminId = reader.GetGuid("adminId"),
                            CreateDate = reader.GetDateTime("createDate"),
                            UpdateDate = reader.GetDateTime("updateDate")
                        };

                        newsList.Add(news);
                    }
                }
            }
            _connection.Close();
            return newsList;
        }
        public List<News> GetAllForUser()
        {
            _connection.Open();
            string query = "select imageUrl,description,createDate from news where deleteDate is null and newsCheck = true";
            List<News> newsList = new List<News>();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        News news = new News()
                        {
                            ImageUrl = reader.GetString("imageUrl"),
                            Description = reader.GetString("description"),
                            CreateDate = reader.GetDateTime("createDate")
                        };
                        newsList.Add(news);
                    }
                }
            }
            _connection.Close();
            return newsList;
        }
    }
}