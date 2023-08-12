using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class SliderAddDto
    {
        public HttpPostedFileBase ImageUrl { get; set; }
        public bool Check { get; set; }
        public Guid AdminId { get; set; }
    }
}