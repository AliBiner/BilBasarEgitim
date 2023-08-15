using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos.TrainingPublication
{
    public class TrainingPublicationPlacementUpdateDto
    {
        public List<int> PlacementUpdate { get; set; }
        public List<Guid> TraningPublicationId { get; set; }
    }
}