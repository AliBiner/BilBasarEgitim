using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class DocumentPreviewDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string DocumentUrl { get; set; }
        public string CreateDate { get; set; }
    }
}