using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos.TrainingPublication
{
    public class TrainingPublicationForAdminDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Check { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
    }
}