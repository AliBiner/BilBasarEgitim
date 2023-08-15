using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilBasarEgitim.Models.Dtos.AcademicStaff
{
    public class AcademicStaffAddDto
    {
        public AcademicStaffAddDto()
        {
            FacebookUrl = "Boş";
            TwitterUrl = "Boş";
            InstagramUrl = "Boş";
        }
        [Required(ErrorMessage = "Boş Bırakılamaz.")]
        public HttpPostedFileBase File { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz.")]
        [MaxLength(144,ErrorMessage = "Max. 144 Karakter Girebilirsiniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz.")]
        [MaxLength(144, ErrorMessage = "Max. 144 Karakter Girebilirsiniz.")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz.")]
        [MaxLength(50, ErrorMessage = "Max. 50 Karakter Girebilirsiniz.")]
        public string EducatorField { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }


        [Required(ErrorMessage = "Boş Bırakılamaz.")]
        public bool Check { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz.")]
        public Guid AdminId { get; set; }
    }
}