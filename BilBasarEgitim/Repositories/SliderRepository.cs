using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Entities;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories
{
    public class SliderRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());
        public void Add(Slider entity)
        {
            _connection.Open();
            string query = "insert into sliders (id,imageUrl,createDate,adminId,sliderCheck) values (@id,@imageUrl,@createDate,@adminId,@sliderCheck)";
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("id", Guid.NewGuid());
                command.Parameters.AddWithValue("imageUrl", entity.ImageUrl);
                command.Parameters.AddWithValue("createDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("adminId", entity.AdminId);
                command.Parameters.AddWithValue("sliderCheck", entity.Check);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public void Update(Slider entitiy)
        {
            _connection.Open();
            string query = "update sliders set updateDate=@updateDate, sliderCheck=@sliderCheck where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", entitiy.Id);
                //command.Parameters.AddWithValue("imageUrl", entitiy.ImageUrl);
                command.Parameters.AddWithValue("updateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("sliderCheck", entitiy.Check);
                command.ExecuteNonQuery();

            }
            _connection.Close();
        }

        public void Delete(Guid id)
        {
            _connection.Open();
            string query = "update sliders set deleteDate=@deleteDate,sliderCheck=false where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("deleteDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public Slider GetById(Guid id)
        {
            _connection.Open();
            string query = "select * from sliders where Id=@Id";
            Slider slider = new Slider();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        slider.Id = reader.GetGuid("Id");
                        slider.ImageUrl = reader.GetString("ImageUrl");
                        slider.CreateDate = reader.GetDateTime("CreateDate");
                        slider.UpdateDate = reader.GetDateTime("UpdateDate");
                        slider.Check = reader.GetBoolean("sliderCheck");
                        slider.AdminId = reader.GetGuid("AdminId");
                    }
                }
            }
            _connection.Close();
            return slider;
        }

        public List<Slider> GetAllNotDelete()
        {
            _connection.Open();
            string query = "select * from sliders where deleteDate is null order by createDate desc";
            List<Slider> sliders = new List<Slider>();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Slider slider = new Slider()
                        {
                            Id = reader.GetGuid("Id"),
                            ImageUrl = reader.GetString("imageUrl"),
                            Check = reader.GetBoolean("sliderCheck"),
                            AdminId = reader.GetGuid("adminId"),
                            CreateDate = reader.GetDateTime("createDate"),
                            UpdateDate = reader.GetDateTime("updateDate")
                        };

                        sliders.Add(slider);
                    }
                }
            }
            _connection.Close();
            return sliders;
        }


        public List<Slider> GetAllForUser()
        {
            _connection.Open();
            string query = "select imageUrl from sliders where deleteDate is null and sliderCheck = true order by createDate desc";
            List<Slider> sliders = new List<Slider>();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Slider slider = new Slider()
                        {
                            ImageUrl = reader.GetString("imageUrl")
                        };
                        sliders.Add(slider);
                    }
                }
            }
            _connection.Close();
            return sliders;
        }
    }
}