using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class GabungPengembangan
    {
        public List<RefJenisAppraisal> jenis { get; set; }
        public int IdRefPengembangan { get; set; }
        [Required]
        public string Deskripsi { get; set; }
        public int? IdRefJnsAppraisal { get; set; }
    }
}
