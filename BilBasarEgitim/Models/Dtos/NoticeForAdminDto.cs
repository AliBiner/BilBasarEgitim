using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class NoticeForAdminDto
    {
        public Guid Id { get; set; }
        public string NoticeUrl { get; set; }
        public string Description { get; set; }
        public string Header { get; set; }
        public string Check { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}