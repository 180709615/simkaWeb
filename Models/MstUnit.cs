using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class MstUnit
    {
        public MstUnit()
        {
            InverseMstIdUnitNavigation = new HashSet<MstUnit>();
            MstKaryawanIdUnitNavigation = new HashSet<MstKaryawan>();
            MstKaryawanMstIdUnitNavigation = new HashSet<MstKaryawan>();
            TblPersonilPenelitian = new HashSet<TblPersonilPenelitian>();
            TblPersonilPengabdian = new HashSet<TblPersonilPengabdian>();
            TblUsulanRekrutmen = new HashSet<TblUsulanRekrutmen>();
            TrMutasiIdUnitNavigation = new HashSet<TrMutasi>();
            TrMutasiMstIdUnitNavigation = new HashSet<TrMutasi>();
                TrKarirStrukturalIdUnitNavigation = new HashSet<TrKarirStruktural>();
        }

        public int IdUnit { get; set; }
        public int? MstIdUnit { get; set; }
        public int? IdRefStruktural { get; set; }
        public string Npp { get; set; }
        public string NamaUnit { get; set; }
        public string KodeUnit { get; set; }
        public int? Level { get; set; }
        public string NamaUnitEn { get; set; }
        public bool? IsDeleted { get; set; }
        public string KodeSatuanKerja { get; set; }
        public int PenanggungJwbSikeu { get; set; }
        public bool? IsPalsu { get; set; }
        public int? HirarkiBiKeu { get; set; }
        public string IdCoaKas { get; set; }
        public bool? EmiSpko { get; set; }
        public int? EmiUnit { get; set; }
        public decimal? PersenPj { get; set; }
        public bool? IsInternasional { get; set; }
        public int? IdFakultas { get; set; }
        public byte[] ImgTtdPejabat { get; set; }

        public RefJabatanStruktural IdRefStrukturalNavigation { get; set; }
        public MstUnit MstIdUnitNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
        public MstUnitAkademik MstUnitAkademik { get; set; }
        public ICollection<MstUnit> InverseMstIdUnitNavigation { get; set; }
        public ICollection<MstKaryawan> MstKaryawanIdUnitNavigation { get; set; }
        public ICollection<MstKaryawan> MstKaryawanMstIdUnitNavigation { get; set; }
        public ICollection<TblPersonilPenelitian> TblPersonilPenelitian { get; set; }
        public ICollection<TblPersonilPengabdian> TblPersonilPengabdian { get; set; }
        public ICollection<TblUsulanRekrutmen> TblUsulanRekrutmen { get; set; }
        public ICollection<TrMutasi> TrMutasiIdUnitNavigation { get; set; }
        public ICollection<TrMutasi> TrMutasiMstIdUnitNavigation { get; set; }
        public ICollection<TrKarirStruktural> TrKarirStrukturalIdUnitNavigation { get; set; }
    }
}
