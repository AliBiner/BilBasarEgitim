﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Entities
{
    public class SendEmail:BaseEntity
    {
        public string Email { get; set; }
        public Guid AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}