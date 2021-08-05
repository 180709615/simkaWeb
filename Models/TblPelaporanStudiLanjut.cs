using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblPelaporanStudiLanjut
    {
        public int IdPelaporanStudiLanjut { get; set; }
        public int? IdStudiLanjut { get; set; }
        public string Semester { get; set; }
        public string Tahun { get; set; }
        public string Deskripsi { get; set; }
        public byte[] Dokumen { get; set; }

        public TblStudiLanjut IdStudiLanjutNavigation { get; set; }
    }
}
