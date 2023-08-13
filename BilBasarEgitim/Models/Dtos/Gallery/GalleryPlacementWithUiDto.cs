using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos.Gallery
{
    public class GalleryPlacementWithUiDto
    {
        public GalleryPlacementWithUiDto()
        {
            GalleryPlacementDtos = new List<GalleryPlacementDto>();
        }
        public List<GalleryPlacementDto> GalleryPlacementDtos { get; set; }
        public GalleryUi GalleryUi { get; set; }
        
    }
}