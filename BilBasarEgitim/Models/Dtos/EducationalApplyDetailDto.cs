﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class EducationalApplyDetailDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string EducationalField { get; set; }
        public string ParentName { get; set; }
        public string ParentPhone { get; set; }
        public string SchoolName { get; set; }
        public string Grade { get; set; }
        public string CreateDate { get; set; }
    }

}