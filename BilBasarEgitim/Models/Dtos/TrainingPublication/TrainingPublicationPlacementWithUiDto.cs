using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Models.Dtos.Gallery;

namespace BilBasarEgitim.Models.Dtos.TrainingPublication
{
    public class TrainingPublicationPlacementWithUiDto
    {
        public TrainingPublicationPlacementWithUiDto()
        {
            TrainingPublicationPlacementDtos = new List<TrainingPublicationPlacementDto>();
        }
        public List<TrainingPublicationPlacementDto> TrainingPublicationPlacementDtos { get; set; }
        public TrainingPublicationUi TariningPublicationUi { get; set; }
        
    }
}