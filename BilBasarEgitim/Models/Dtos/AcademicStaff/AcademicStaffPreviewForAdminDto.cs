﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BilBasarEgitim.Models.Dtos.AcademicStaff
{
    public class AcademicStaffPreviewForAdminDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string EdicatorField { get; set; }
        public string Check { get; set; }
        public string CreateDate { get; set; }
    }
}