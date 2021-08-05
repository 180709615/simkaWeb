using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class GabungJabatanAkademik
    {
        public List <RefFungsional> Fungsi { get; set; }
        public RefJabatanAkademik Akademik { get; set; }
        public int IdRefJbtnAkademik { get; set; }
        [Required]
        public string Deskripsi { get; set; }
        public int? IdRefFungsional { get; set; }
        [Required]
        public int? UsiaPensiun { get; set; }
    }
}
