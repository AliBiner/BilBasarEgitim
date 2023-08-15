using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class DocumentAddDto
    {
        public HttpPostedFileBase File { get; set; }
        public string Description { get; set; }
        public Guid AdminId { get; set; }
    }
}