using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos.Gallery;
using BilBasarEgitim.Models.Dtos.TrainingPublication;
using BilBasarEgitim.Models.Entities;
using BilBasarEgitim.Repositories;

namespace BilBasarEgitim.Services
{
    public class TrainingPublicationService
    {
        private readonly TrainingPublicationRepository training = new TrainingPublicationRepository();
        public string Add(TrainingPublicationAddDto dto)
        {
            try
            {
                var model = CustomMapper.TrainingPublicationAddDtoTo(dto);
                var publicationUrl = CustomMethod.TrainingPublicationImageUpload(dto.ImageUrl);
                if (publicationUrl == null)
                {
                    return "Resim Seçili Değil.";
                }
                model.ImageUrl = publicationUrl;
                training.Add(model);
                return "Kayıt İşlemi Başarılı.";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "İşlem Hatası";
            }

        }

        public List<TrainingPublicationForAdminDto> GetAllNotDelete()
        {
            try
            {
                var modellist = training.GetAllNotDelete();
                var dtolist = CustomMapper.ToTrainingPublicationsDto(modellist);
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
            var trainingPublication = new TrainingPublication()
            {
                Id = Id,
                Check = check,
            };

            training.Update(trainingPublication);
        }

        public void Delete(Guid id)
        {
            var publicationUrl = training.GetById(id).ImageUrl;
            training.Delete(id);
            CustomMethod.TrainingPublicationImageDelete(publicationUrl);
        }

        public List<TrainingPublicationForUserDto> GetAllForUser()
        {
            try
            {
                var modellist = training.GetAllForUser();
                var dtolist = CustomMapper.ToTrainingPublicationsForUserDto(modellist);
                return dtolist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public TrainingPublicationPlacementWithUiDto GetAllForPlacement()
        {
            var model = training.GetAllForPlacement();
            var dtos = CustomMapper.ToTrainingPublicationPlacementDtos(model);

            var ui = TrainingPublicationPlacementUi(dtos);
            TrainingPublicationPlacementWithUiDto dto = new TrainingPublicationPlacementWithUiDto();
            dto.TrainingPublicationPlacementDtos = dtos;
            dto.TariningPublicationUi = ui;

            return dto;
        }

        private TrainingPublicationUi TrainingPublicationPlacementUi(List<TrainingPublicationPlacementDto> dtos)
        {
            var lineDoubleNumber = dtos.Count / 4.0;
            var lineIntNumber = Convert.ToInt32(Math.Ceiling(lineDoubleNumber));

            var datanum = dtos.Count % 4;
            int datanumlastLine;
            if (datanum == 0)
            {
                datanumlastLine = dtos.Count - (lineIntNumber - 1) * 4;
            }
            else
            {
                datanumlastLine = datanum;
            }
            var model = new TrainingPublicationUi()
            {
                LineNumber = lineIntNumber,
                DataNumInLastLine = datanumlastLine
            };
            return model;
        }

        public void TrainingPublicationPlacementUpdate(TrainingPublicationPlacementUpdateDto dto)
        {
            var models = CustomMapper.TrainingPublicationPlacementUpdateDtoto(dto);
            training.TrainingPublicationPlacementUpdate(models);
        }
    }
}