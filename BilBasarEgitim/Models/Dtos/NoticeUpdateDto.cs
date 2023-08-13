using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class NoticeUpdateDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Header { get; set; }
        public string NoticeUrl { get; set; }
        public bool Check { get; set; }
    }
}