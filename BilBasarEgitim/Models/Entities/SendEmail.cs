﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Entities
{
    public class SendEmail
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}