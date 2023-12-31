﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace BilBasarEgitim.Models.Entities
{
    public class Admin:BaseEntity
    {
        public Admin()
        {
            Documents = new List<Document>();
            Sliders = new List<Slider>();
            Notices = new List<Notice>();
            News = new List<News>();
            AcademicStaffs = new List<AcademicStaff>();
            Galleries = new List<Gallery>();
            TrainingPublications = new List<TrainingPublication>();
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        

        public List<Document> Documents { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Notice> Notices { get; set; }
        public List<News> News { get; set; }
        public List<AcademicStaff> AcademicStaffs { get; set; }
        public List<Gallery> Galleries { get; set; }
        public List<TrainingPublication> TrainingPublications { get; set; }
        
    }
}