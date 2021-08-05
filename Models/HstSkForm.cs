using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class HstSkForm
    {

        [Required]
        public string NoSk { get; set; }
        public int? NoSemester { get; set; }
        public DateTime? TglSk { get; set; }
        public string DeskripsiSk { get; set; }
        public DateTime? TglAwal { get; set; }
        public DateTime? TglAkhir { get; set; }
        public byte[] FileSk { get; set; }
        public IFormFile FileSkform { get; set; }
        public int? IdTahunAkademik { get; set; }
        public string LevelSk { get; set; }
        public int? IdRefJenisSk { get; set; }
        public DateTime? DateInserted { get; set; }

        public RefJenisSk IdRefJenisSkNavigation { get; set; }
        public ICollection<TrKenaikanPangkat> TrKenaikanPangkat { get; set; }
        public ICollection<TrKgb> TrKgb { get; set; }
        public ICollection<TrPensiun> TrPensiun { get; set; }
    }
}
