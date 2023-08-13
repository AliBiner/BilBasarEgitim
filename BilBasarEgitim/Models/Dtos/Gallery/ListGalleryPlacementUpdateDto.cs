using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos.Gallery
{
    public class ListGalleryPlacementUpdateDto
    {
        public ListGalleryPlacementUpdateDto()
        {
            GalleryPlacementUpdateDtos = new List<GalleryPlacementUpdateDto>();
        }
        public List<GalleryPlacementUpdateDto> GalleryPlacementUpdateDtos { get; set; }
    }
}