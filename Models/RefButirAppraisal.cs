using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class RefButirAppraisal
    {
        [Required]
        public int IdRefAppraisal { get; set; }
        public int? IdRefJnsAppraisal { get; set; }
        public int? IdRefFungsional { get; set; }
        public string Deskripsi { get; set; }

        public RefFungsional IdRefFungsionalNavigation { get; set; }
        public RefJenisAppraisal IdRefJnsAppraisalNavigation { get; set; }
    }
}
