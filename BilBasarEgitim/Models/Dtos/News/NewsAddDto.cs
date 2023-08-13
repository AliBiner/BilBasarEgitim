using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos.News
{
    public class NewsAddDto
    {
        public HttpPostedFileBase NewsUrl { get; set; }
        public string Description { get; set; }
        public bool Check { get; set; }
        public Guid AdminId { get; set; }
    }
}