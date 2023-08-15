using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class SendEmailUpdateDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}