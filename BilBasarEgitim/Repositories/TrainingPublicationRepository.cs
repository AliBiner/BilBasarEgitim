using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Entities;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories
{
    public class TrainingPublicationRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());
        public void Add(TrainingPublication entity)
        {
            _connection.Open();
            string query = "insert into trainingPublications (id,imageUrl,createDate,adminId,trainingPublicationCheck,description) values (@id,@imageUrl,@createDate,@adminId,@trainingPublicationCheck,@description)";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("id", Guid.NewGuid());
                command.Parameters.AddWithValue("imageUrl", entity.ImageUrl);
                command.Parameters.AddWithValue("createDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("adminId", entity.AdminId);
                command.Parameters.AddWithValue("trainingPublicationCheck", entity.Check);
                command.Parameters.AddWithValue("description", entity.Description);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public void Update(TrainingPublication entitiy)
        {
            _connection.Open();
            string query = "update trainingPublications set updateDate=@updateDate, trainingPublicationCheck=@trainingPublicationCheck where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", entitiy.Id);
                //command.Parameters.AddWithValue("imageUrl", entitiy.ImageUrl);
                command.Parameters.AddWithValue("updateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("trainingPublicationCheck", entitiy.Check);
                command.ExecuteNonQuery();

            }
            _connection.Close();
        }

        public void Delete(Guid id)
        {
            _connection.Open();
            string query = "update trainingPublications set deleteDate=@deleteDate,trainingPublicationCheck=false where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("deleteDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public TrainingPublication GetById(Guid id)
        {
            _connection.Open();
            string query = "select * from trainingPublications where Id=@Id";
            TrainingPublication trainingPublication = new TrainingPublication();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        trainingPublication.Id = reader.GetGuid("Id");
                        trainingPublication.ImageUrl = reader.GetString("ImageUrl");
                        trainingPublication.CreateDate = reader.GetDateTime("CreateDate");
                        trainingPublication.UpdateDate = reader.GetDateTime("UpdateDate");
                        trainingPublication.Check = reader.GetBoolean("trainingPublicationCheck");
                        trainingPublication.AdminId = reader.GetGuid("AdminId");
                    }
                }
            }
            _connection.Close();
            return trainingPublication;
        }

        public List<TrainingPublication> GetAllNotDelete()
        {
            _connection.Open();
            string query = "select * from trainingPublications where deleteDate is null order by createDate desc";
            List<TrainingPublication> trainingPublications = new List<TrainingPublication>();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TrainingPublication trainingPublication = new TrainingPublication()
                        {
                            Id = reader.GetGuid("Id"),
                            ImageUrl = reader.GetString("imageUrl"),
                            Check = reader.GetBoolean("trainingPublicationCheck"),
                            AdminId = reader.GetGuid("adminId"),
                            CreateDate = reader.GetDateTime("createDate"),
                            UpdateDate = reader.GetDateTime("updateDate"),
                            Description = reader.GetString("description")
                        };

                        trainingPublications.Add(trainingPublication);
                    }
                }
            }
            _connection.Close();
            return trainingPublications;
        }

        public List<TrainingPublication> GetAllForPlacement()
        {
            _connection.Open();
            string query = "select id,imageUrl,description,placement,trainingPublicationCheck from trainingPublications where deleteDate is null order by placement asc,createDate desc";
            List<TrainingPublication> trainingPublications = new List<TrainingPublication>();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TrainingPublication trainingPublication = new TrainingPublication()
                        {
                            Id = reader.GetGuid("Id"),
                            ImageUrl = reader.GetString("imageUrl"),
                            Description = reader.GetString("description"),
                            Placement = reader.GetInt32("placement"),
                            Check = reader.GetBoolean("trainingPublicationCheck")

                        };
                        trainingPublications.Add(trainingPublication);
                    }
                }
            }
            _connection.Close();
            return trainingPublications;
        }

        public List<TrainingPublication> GetAllForUser()
        {
            _connection.Open();
            string query = "select imageUrl,description from trainingPublications where deleteDate is null and trainingPublicationCheck = true order by placement asc,createDate desc";
            List<TrainingPublication> trainingPublications = new List<TrainingPublication>();
            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TrainingPublication trainingPublication = new TrainingPublication()
                        {
                            ImageUrl = reader.GetString("imageUrl"),
                            Description = reader.GetString("description")
                        };
                        trainingPublications.Add(trainingPublication);
                    }
                }
            }
            _connection.Close();
            return trainingPublications;
        }

        public void TrainingPublicationPlacementUpdate(List<TrainingPublication> dto)
        {
            _connection.Open();
            string query = "update trainingPublications set placement=@placement where id=@id";
            for (int i = 0; i < dto.Count; i++)
            {
                using (MySqlCommand command = new MySqlCommand(query, _connection))
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