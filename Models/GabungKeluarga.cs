using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class GabungKeluarga
    {
        public List <RefKeluarga> RefKeluargas { get; set; }
        public int IdKeluarga { get; set; }
        [Required]
        public string Npp { get; set; }
        [Range(1, 1000,
         ErrorMessage = "harap Pilih Hubungan Keluarga")]
        public int? IdRefKeluarga { get; set; }
        [Required]
        public string Nama { get; set; }
        [Required]
        public string TempatLahir { get; set; }
        [Required]
        public DateTime? TglLahir { get; set; }
        public string JnsKel { get; set; }
        [Required]
        public string GolDarah { get; set; }
        public string StatusSipil { get; set; }
        public IFormFile FileFoto { get; set; }
        public byte[] FileFotom { get; set; }

        public byte[] FileSuratm { get; set; }
        public IFormFile FileSurat { get; set; }
        public bool? IsTanggung { get; set; }
        public bool? IsTanggungYadapen { get; set; }
    }
}
