using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos.AcademicStaff
{
    public class AcademicStaffAddDto
    {
        public AcademicStaffAddDto()
        {
            FacebookUrl = "Boş";
            TwitterUrl = "Boş";
            InstagramUrl = "Boş";
        }
        public HttpPostedFileBase File { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        
        public string EducatorField { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public bool Check { get; set; }
        public Guid AdminId { get; set; }
    }
}