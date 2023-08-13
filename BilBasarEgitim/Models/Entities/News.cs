using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Entities
{
    public class News: BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public Guid AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}