using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos.AcademicStaff
{
    public class AcademicStaffUpdateDto
    {
        public Guid Id { get; set; }
        public HttpPostedFileBase File { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EducatorField { get; set; }
        public string FaceBookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
    }
}