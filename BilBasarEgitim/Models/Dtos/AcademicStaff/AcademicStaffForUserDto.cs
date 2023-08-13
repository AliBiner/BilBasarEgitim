using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos.AcademicStaff
{
    public class AcademicStaffForUserDto
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
    }
}