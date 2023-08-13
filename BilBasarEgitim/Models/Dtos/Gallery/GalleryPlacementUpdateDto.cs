using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos.Gallery
{
    public class GalleryPlacementUpdateDto
    {
        public List<int> PlacementUpdate { get; set; }
        public List<Guid> GalleryId { get; set; }
    }
}