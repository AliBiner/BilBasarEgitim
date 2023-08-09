using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
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


        //public string SendEmail(JopApplyAddDto entitiy,string subject)
        //{
        //    var sendemail = GetEmail().Email;
        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(sendemail);
        //    mail.From= new MailAddress("system@tmkmuhendislik.com");
        //    mail.Subject = subject;
        //    mail.Body = "Sayın Ali Biner," + entitiy.FullName + "iş başvurusnda bulunmuştur. <br>" + entitiy.Email +
        //                "<br>" + entitiy.Phone + "<br>";

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Credentials = new NetworkCredential("system@tmkmuhendislik.com", "CMbc3_2_r@9.fNM6");
        //    smtp.Port = 587;
        //    smtp.Host = "mail.kurumsaleposta.com";
        //    smtp.EnableSsl = true;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;


        //    try
        //    {
        //        smtp.Send(mail);
        //        return "Mail Gönderildi.";
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return "Mail Gönderilemedi";
        //    }


        //}

    }
}