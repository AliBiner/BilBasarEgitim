using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Entities;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories
{
    public class SendEmailRepository
    {
        private readonly MySqlConnection _connection = new MySqlConnection(CustomMethod.ConnectionString());

        public void Update(Guid id,string email)
        {
            _connection.Open();
            string query = "update sendemails set UpdateDate = @UpdateDate,Email=@Email where Id=@Id";
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("UpdateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("Email", email);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public SendEmail GetEmail()
        {
            _connection.Open();
            string query = "select * from sendemails limit 1";
            SendEmail sendEmail = new SendEmail();
            using (MySqlCommand command = new MySqlCommand(query,_connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        sendEmail.Id = reader.GetGuid("Id");
                        sendEmail.Email = reader.GetString("Email");
                        sendEmail.UpdateDate = reader.GetDateTime("UpdateDate");
                    }
                }
            }
            _connection.Close();
            return sendEmail;
        }

    }
}