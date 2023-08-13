using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.News
{
    public class NewsForUserDto
    {
        public string NewsUrl { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
    }
}