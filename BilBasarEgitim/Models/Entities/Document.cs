using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Entities
{
    public class Document:BaseEntity
    {
        public string Description { get; set; }
        public string DocumentUrl { get; set; }
        public Guid AdminId { get; set; }
        public Admin Admin { get; set; }
        
    }
}