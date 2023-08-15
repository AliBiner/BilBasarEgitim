﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos.TrainingPublication
{
    public class TrainingPublicationPlacementDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Placement { get; set; }
        public bool Check { get; set; }
    }
}