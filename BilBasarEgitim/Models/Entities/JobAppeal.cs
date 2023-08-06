using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Entities
{
    public class JobAppeal:BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public string JobRole { get; set; }
        public string Gender { get; set; }
        public string MartialStatus { get; set; }
        public string Nationality { get; set; }
        public string GraduateSchool { get; set; }
        public string JobExperience { get; set; }
        public string CvUrl { get; set; }
    }
}