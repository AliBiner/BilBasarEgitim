using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BilBasarEgitim.Mappers;
using BilBasarEgitim.Methods;
using BilBasarEgitim.Models.Dtos;
using BilBasarEgitim.Repositories;

namespace BilBasarEgitim.Services
{
    public class DocumentService
    {
        private readonly DocumentRepository _documentRepository = new DocumentRepository();

        public string Add(DocumentAddDto dto,HttpPostedFileBase document)
        {
            try
            {
                var documentUrl = CustomMethod.DocumentUpload(document);
                if (documentUrl == null)
                {
                    return "Lütfen Resim Seçiniz.";
                }
                var model = CustomMapper.DocumentAddDtoTo(dto);
                model.DocumentUrl = documentUrl;
                _documentRepository.Add(model);
                return "İşlem Başarılı";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "İşlem Hatası";
            }
        }

        public List<DocumentPreviewDto> GetAll()
        {
            try
            {
                var model = _documentRepository.GetAll();
                var dtos = CustomMapper.ToDocumentPreviewDtos(model);
                return dtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
           
        }

        public void Delete(Guid id)
        {
            var model = _documentRepository.GetById(id);
            CustomMethod.DocumentDelete(model.DocumentUrl);
            _documentRepository.Delete(id);
        }
    }
}