using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Entities;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories
{
    public class DocumentRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());
        public void Add(Document entity)
        {
            _connection.Open();
            string query =
                "insert into documents (Id,Description,DocumentUrl,CreateDate,DocumentCheck,AdminId) values (@Id,@Description,@DocumentUrl,@CreateDate,@DocumentCheck, @AdminId)";

            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", Guid.NewGuid());
                command.Parameters.AddWithValue("Description", entity.Description);
                command.Parameters.AddWithValue("DocumentUrl", entity.DocumentUrl);
                command.Parameters.AddWithValue("CreateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("DocumentCheck", true);
                command.Parameters.AddWithValue("AdminId", entity.AdminId);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public void Delete(Guid id)
        {
            _connection.Open();
            string query = "update documents set DeleteDate = @DeleteDate, DocumentCheck=false where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("DeleteDate", CustomMethod.TurkeyTime());
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public List<Document> GetAll()
        {
            _connection.Open();
            string query =
                "select Id,Description,DocumentUrl,CreateDate from documents where DeleteDate is null and DocumentCheck=true";
            List<Document> documents = new List<Document>();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Document document = new Document()
                        {
                            Id = reader.GetGuid("Id"),
                            Description = reader.GetString("Description"),
                            DocumentUrl = reader.GetString("DocumentUrl"),
                            CreateDate = reader.GetDateTime("CreateDate")
                        };
                        documents.Add(document);
                    }
                }
            }
            _connection.Close();
            return documents;
        }

        public Document GetById(Guid id)
        {
            _connection.Open();
            string query = "select * from documents where Id=@Id";
            Document document = new Document();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        document.DocumentUrl = reader.GetString("DocumentUrl");
                    }
                   
                }
            }
            _connection.Close();
            return document;
        }

    }
}