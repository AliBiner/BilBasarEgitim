using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Repositories;

namespace BilBasarEgitim.Services
{
    public class SendEmailService
    {
        private SendEmailRepository _sendEmail = new SendEmailRepository();
        public SendEmailDto GetEmail()
        {
            try
            {
                var model = _sendEmail.GetEmail();
                var dto = CustomMapper.ToSendEmailDto(model);
                return dto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
           
        }

        public void UpdateByEmail(Guid id,string email)
        {
            try
            {
                _sendEmail.Update(id, email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}