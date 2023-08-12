using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos
{
    public class SliderForAdminDto
    {
        public Guid Id { get; set; }
        public string SliderUrl { get; set; }
        public string Check { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}