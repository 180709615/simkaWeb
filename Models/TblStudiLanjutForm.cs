using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class TblStudiLanjutForm
    {
        public int IdStudiLanjut { get; set; }
        [Required]
        public string Npp { get; set; }
        public int? IdRefJenjang { get; set; }
        [Required]
        public string NamaSekolah { get; set; }
        [Required]
        public string KotaSekolah { get; set; }
        [Required]

        public string NegaraSekolah { get; set; }
        [Required]

        public DateTime? TglMulai { get; set; }
        public DateTime? TglLulus { get; set; }
        public DateTime? TglPenempatanKmbli { get; set; }
        [Required]

        public string Fakultas { get; set; }
        [Required]

        public string Prodi { get; set; }
        [Required]

        public string DlmNegriLuarNegri { get; set; }
        [Required]

        public string NoSkTugasBljr { get; set; }
        [Required]

        public int? TargetLulus { get; set; }
        [Required]

        public int? IdRefSs { get; set; }

        [Required]

        public int? IdSumberBiaya1 { get; set; }

        [Required]

        public int? IdSumberBiaya2 { get; set; }




        public IFormFile SK { get; set; }
        public byte[] SKm { get; set; }
        public IFormFile SkPenempatanKmbl { get; set; }
        public byte[] SkPenempatanKmblm { get; set; }

        public List<RefJenjang> listJenjang { get; set; }

        public List<RefSumberBiaya> listSumberBiaya { get; set; }

        public List<RefStatusStudi> listStatusStudi { get; set; }



    }
}
