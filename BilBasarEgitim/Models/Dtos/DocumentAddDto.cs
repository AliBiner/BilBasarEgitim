using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class DocumentAddDto
    {
        public string Description { get; set; }
        public Guid AdminId { get; set; }
    }
}