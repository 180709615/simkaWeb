using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class GabungButirAppraisal
    {
        public List<RefJenisAppraisal> jenis { get; set; }
        public List<RefFungsional> fungsi { get; set; }
        public RefButirAppraisal butir { get; set; }
        [Required]
        public int IdRefAppraisal { get; set; }
        [Required]
        public int? IdRefJnsAppraisal { get; set; }
        [Required]
        public int? IdRefFungsional { get; set; }
        [Required]
        public string Deskripsi { get; set; }
    }
}
