using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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

        public string UpdateByEmail(Guid id,string email)
        {
            try
            {
                _sendEmail.Update(id, email);
                return "Güncelleme İşlemi Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "İşlem Hatası";
            }
        }


        public string SendEmailForJob(JopApplyAddDto entitiy,HttpPostedFileBase cvUrl)
        {
            var email = GetEmail().Email;
            MailMessage mail = new MailMessage();
            mail.Subject = "İş Başvurusu";
            mail.Body = entitiy.FullName +" " + "iş başvurusunda bulunmuştur. <br>" + entitiy.Email + "<br>" + entitiy.Phone ;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("system@tmkmuhendislik.com", "Mehmet Kara"); ;
            mail.To.Add(new MailAddress(email));
            string fileName = Path.GetFileName(cvUrl.FileName);
            mail.Attachments.Add(new Attachment(cvUrl.InputStream,fileName));
            SmtpClient client = new SmtpClient("mail.kurumsaleposta.com", 587);   
            System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("system@tmkmuhendislik.com", "CMbc3_2_r@9.fNM6");
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                client.Send(mail);
                return "Mail Gönderildi.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Mail Gönderilemedi";
            }


        }


        public string SendEmailForEducational(EducationalApplyAddDto entitiy)
        {
            var email = GetEmail().Email;
            MailMessage mail = new MailMessage();
            mail.Subject = "Eğitim Başvurusu";
            mail.Body = entitiy.FullName + " " + "eğitim başvurusunda bulunmuştur. <br>" + entitiy.Email + "<br>" + entitiy.Phone;
            mail.BodyEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("system@tmkmuhendislik.com", "Mehmet Kara"); ;
            mail.To.Add(new MailAddress(email));
           
            SmtpClient client = new SmtpClient("mail.kurumsaleposta.com", 587);
            System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("system@tmkmuhendislik.com", "CMbc3_2_r@9.fNM6");
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            try
            {
                client.Send(mail);
                return "Mail Gönderildi.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Mail Gönderilemedi";
            }


        }
    }
}