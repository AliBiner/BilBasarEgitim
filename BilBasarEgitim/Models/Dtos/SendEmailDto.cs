﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class SendEmailDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Update { get; set; }
    }
}