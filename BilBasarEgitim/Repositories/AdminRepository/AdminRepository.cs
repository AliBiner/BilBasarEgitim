using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Entities;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace BilBasarEgitim.Repositories.AdminRepository
{
    public class AdminRepository
    {
        private readonly MySqlConnection con = new MySqlConnection(CustomMethod.ConnectionString());
        public void Add(Admin entity)
        {
            con.Open();
            string insertQuery = @"INSERT INTO Admins
                                  (Id, FullName, Email, Password, CreateDate, UpdateDate, DeleteDate, AdminCheck)
                                  VALUES
                                  (@Id, @FullName, @Email, @Password, @CreateDate, @UpdateDate, @DeleteDate, @AdminCheck)";


            using (MySqlCommand command = new MySqlCommand(insertQuery, con))
            {
                command.Parameters.AddWithValue("@Id", Guid.NewGuid().ToString()); // Generate a new GUID
                command.Parameters.AddWithValue("@FullName", entity.FullName);
                command.Parameters.AddWithValue("@Email", entity.Email);
                command.Parameters.AddWithValue("@Password", entity.Password); // Hashed or encrypted password
                command.Parameters.AddWithValue("@CreateDate", CustomMethod.TurkeyTime());
                command.Parameters.AddWithValue("@UpdateDate", DBNull.Value);
                command.Parameters.AddWithValue("@DeleteDate", DBNull.Value);
                command.Parameters.AddWithValue("@AdminCheck", true);

                command.ExecuteNonQuery();
            }
            con.Close();
        }

        public bool GetAll(string email)
        {
            con.Open();
            string query = "select * from admins";
            string id = null;
            using (MySqlCommand command = new MySqlCommand(query,con))
            {

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader.GetString("Email");
                    }
                }
            }

            if (id==null)
            {
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;
            }
        }

        public Admin LoginControl(string email, string password)
        {
            con.Open();
            string query = "select Id,Email,FullName from admins where Email = @Email and Password = @Password";

            using (MySqlCommand command = new MySqlCommand(query,con))
            {
                command.Parameters.AddWithValue("Email", email);
                command.Parameters.AddWithValue("Password", password);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Admin admin = new Admin()
                        {
                            Id = reader.GetGuid("Id"),
                            Email = reader.GetString("Email"),
                            FullName = reader.GetString("FullName")
                        };
                        return admin;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}