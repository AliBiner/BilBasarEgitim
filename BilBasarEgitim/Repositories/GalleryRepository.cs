using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Dtos.Gallery;
using BilBasarEgitim.Models.Entities;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories
{
    public class GalleryRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());
        public void Add(Gallery entity)
        {
            _connection.Open();
            string query = "insert into galleries (id,imageUrl,createDate,adminId,galleryCheck,description) values (@id,@imageUrl,@createDate,@adminId,@galleryCheck,@description)";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("id", Guid.NewGuid());
                command.Parameters.AddWithValue("imageUrl", entity.ImageUrl);
                command.Parameters.AddWithValue("createDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("adminId", entity.AdminId);
                command.Parameters.AddWithValue("galleryCheck", entity.Check);
                command.Parameters.AddWithValue("description", entity.Description);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public void Update(Gallery entitiy)
        {
            _connection.Open();
            string query = "update galleries set updateDate=@updateDate, galleryCheck=@galleryCheck where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", entitiy.Id);
                //command.Parameters.AddWithValue("imageUrl", entitiy.ImageUrl);
                command.Parameters.AddWithValue("updateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("galleryCheck", entitiy.Check);
                command.ExecuteNonQuery();

            }
            _connection.Close();
        }

        public void Delete(Guid id)
        {
            _connection.Open();
            string query = "update galleries set deleteDate=@deleteDate,galleryCheck=false where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("deleteDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public Gallery GetById(Guid id)
        {
            _connection.Open();
            string query = "select * from galleries where Id=@Id";
            Gallery gallery = new Gallery();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        gallery.Id = reader.GetGuid("Id");
                        gallery.ImageUrl = reader.GetString("ImageUrl");
                        gallery.CreateDate = reader.GetDateTime("CreateDate");
                        gallery.UpdateDate = reader.GetDateTime("UpdateDate");
                        gallery.Check = reader.GetBoolean("galleryCheck");
                        gallery.AdminId = reader.GetGuid("AdminId");
                    }
                }
            }
            _connection.Close();
            return gallery;
        }

        public List<Gallery> GetAllNotDelete()
        {
            _connection.Open();
            string query = "select * from galleries where deleteDate is null order by createDate desc";
            List<Gallery> galleries = new List<Gallery>();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Gallery gallery = new Gallery()
                        {
                            Id = reader.GetGuid("Id"),
                            ImageUrl = reader.GetString("imageUrl"),
                            Check = reader.GetBoolean("galleryCheck"),
                            AdminId = reader.GetGuid("adminId"),
                            CreateDate = reader.GetDateTime("createDate"),
                            UpdateDate = reader.GetDateTime("updateDate"),
                            Description = reader.GetString("description")
                        };

                        galleries.Add(gallery);
                    }
                }
            }
            _connection.Close();
            return galleries;
        }

        public List<Gallery> GetAllForPlacement()
        {
            _connection.Open();
            string query = "select id,imageUrl,description,placement,galleryCheck from galleries where deleteDate is null order by placement asc,createDate desc";
            List<Gallery> galleries = new List<Gallery>();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())        
                {
                    while (reader.Read())
                    {
                        Gallery gallery = new Gallery()
                        {
                            Id = reader.GetGuid("Id"),
                            ImageUrl = reader.GetString("imageUrl"),
                            Description = reader.GetString("description"),
                            Placement = reader.GetInt32("placement"),
                            Check = reader.GetBoolean("galleryCheck")
                            
                        };
                        galleries.Add(gallery);
                    }
                }
            }
            _connection.Close();
            return galleries;
        }

        public List<Gallery> GetAllForUser()
        {
            _connection.Open();
            string query = "select imageUrl,description from galleries where deleteDate is null and galleryCheck = true order by placement asc,createDate desc";
            List<Gallery> galleries = new List<Gallery>();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Gallery gallery = new Gallery()
                        {
                            ImageUrl = reader.GetString("imageUrl"),
                            Description = reader.GetString("description")
                        };
                        galleries.Add(gallery);
                    }
                }
            }
            _connection.Close();
            return galleries;
        }

        public void GalleryPlacementUpdate(List<Gallery> dto)
        {
            _connection.Open();
            string query = "update galleries set placement=@placement where id=@id";
            for (int i = 0; i < dto.Count; i++)
            {
                using (MySqlCommand command = new MySqlCommand(query,_connection))
                {
                   
                    command.Parameters.AddWithValue("id", dto[i].Id);
                    command.Parameters.AddWithValue("placement", dto[i].Placement);
                    command.ExecuteNonQuery();
                }
            }
            _connection.Close();
        }
    }
}