using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class TblStudiLanjut
    {
        public TblStudiLanjut()
        {
            TblPelaporanStudiLanjut = new HashSet<TblPelaporanStudiLanjut>();
            TblPerpanjanganStudiLanjut = new HashSet<TblPerpanjanganStudiLanjut>();
            TblSumberBiayaSl = new HashSet<TblSumberBiayaSl>();
        }

        public int IdStudiLanjut { get; set; }
        public string Npp { get; set; }
        public int? IdRefJenjang { get; set; }
        [Required]
        public string NamaSekolah { get; set; }
        public string KotaSekolah { get; set; }
        public string NegaraSekolah { get; set; }
        public DateTime? TglMulai { get; set; }
        public DateTime? TglLulus { get; set; }
        public byte[] Sk { get; set; }
        public DateTime? TglPenempatanKmbli { get; set; }
        public byte[] SkPenempatanKmbl { get; set; }
        public string Fakultas { get; set; }
        public string Prodi { get; set; }
        public string DlmNegriLuarNegri { get; set; }
        public string NoSkTugasBljr { get; set; }
        public int? TargetLulus { get; set; }
        public int? IdRefSs { get; set; }

        public RefJenjang IdRefJenjangNavigation { get; set; }
        public RefStatusStudi IdRefSsNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
        public ICollection<TblPelaporanStudiLanjut> TblPelaporanStudiLanjut { get; set; }
        public ICollection<TblPerpanjanganStudiLanjut> TblPerpanjanganStudiLanjut { get; set; }
        public ICollection<TblSumberBiayaSl> TblSumberBiayaSl { get; set; }
    }
}
