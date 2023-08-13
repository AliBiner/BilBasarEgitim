using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace BilBasarEgitim.Models.News
{
    public class NewsUpdateDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string NewsUrl { get; set; }
        public bool Check { get; set; }
    }
}