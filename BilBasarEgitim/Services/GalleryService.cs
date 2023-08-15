using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Models.Dtos.Gallery;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Repositories;

namespace BilBasarEgitim.Services
{
    public class GalleryService
    {
        private readonly GalleryRepository galleryRepository = new GalleryRepository();

        public string Add(GalleryAddDto dto)
        {
            try
            {
                var model = CustomMapper.GalleryAddDtoTo(dto);
                var galleryUrl = CustomMethod.GalleryImageUpload(dto.ImageUrl);
                if (galleryUrl == null)
                {
                    return "Resim Seçili Değil.";
                }
                model.ImageUrl = galleryUrl;
                galleryRepository.Add(model);
                return "Kayıt İşlemi Başarılı.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "İşlem Hatası";
            }

        }

        public List<GalleryForAdminDto> GetAllNotDelete()
        {
            try
            {
                var modellist = galleryRepository.GetAllNotDelete();
                var dtolist = CustomMapper.ToGalleriesDto(modellist);
                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void Update(Guid Id, bool check)
        {
            var gallery = new Gallery()
            {
                Id = Id,
                Check = check,
            };

            galleryRepository.Update(gallery);
        }

        public void Delete(Guid id)
        {
            var galleryUrl = galleryRepository.GetById(id).ImageUrl;
            galleryRepository.Delete(id);
            CustomMethod.GalleryImageDelete(galleryUrl);
        }

        public List<GalleryForUserDto> GetAllForUser()
        {
            try
            {
                var modellist = galleryRepository.GetAllForUser();
                var dtolist = CustomMapper.ToGalleriesForUserDto(modellist);
                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public GalleryPlacementWithUiDto GetAllForPlacement()
        {
            var model = galleryRepository.GetAllForPlacement();
            var dtos = CustomMapper.ToGalleryPlacementDtos(model);

            var ui = GalleryPlacementUi(dtos);
            GalleryPlacementWithUiDto dto = new GalleryPlacementWithUiDto();
            dto.GalleryPlacementDtos = dtos;
            dto.GalleryUi = ui;

            return dto;
        }

        private GalleryUi GalleryPlacementUi(List<GalleryPlacementDto> dtos)
        {
            var lineDoubleNumber = dtos.Count / 4.0;
            var lineIntNumber = Convert.ToInt32(Math.Ceiling(lineDoubleNumber));

            var datanum = dtos.Count % 4;
            int datanumlastLine;
            if (datanum == 0)
            {
                datanumlastLine = dtos.Count - (lineIntNumber -1) * 4;
            }
            else
            {
                datanumlastLine = datanum;
            }
            var model = new GalleryUi()
            {
                LineNumber = lineIntNumber,
                DataNumInLastLine = datanumlastLine
            };
            return model;
        }

        public void GalleryPlacementUpdate(GalleryPlacementUpdateDto dto)
        {
            var models = CustomMapper.GalleryPlacementUpdateDtoto(dto);
            galleryRepository.GalleryPlacementUpdate(models);
        }
    }
}