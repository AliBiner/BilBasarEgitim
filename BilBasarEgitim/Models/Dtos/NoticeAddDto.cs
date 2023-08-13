﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class NoticeAddDto
    {
        public HttpPostedFileBase NoticeUrl { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public bool Check { get; set; }
        public Guid AdminId { get; set; }
    }
}