using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Entities
{
    public class AcademicStaff: BaseEntity
    {
        public AcademicStaff()
        {
            FaceBookUrl = "Boş";
            TwitterUrl = "Boş";
            InstagramUrl = "Boş";
        }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        [DefaultValue("Boş")]
        public string EducatorField { get; set; }
        [DefaultValue("Boş")]
        public string FaceBookUrl { get; set; }
        [DefaultValue("Boş")]
        public string TwitterUrl { get; set; }
        [DefaultValue("Boş")]
        public string InstagramUrl { get; set; }
        public Guid AdminId { get; set; }
        public Admin Admin { get; set; }

    }
}