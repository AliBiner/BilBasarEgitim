﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class JobApplyPreviewDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string JobRole { get; set; }
        public int Age { get; set; }
        public string CreateDate { get; set; }
    }
}