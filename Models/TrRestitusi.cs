using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrRestitusi
    {
        public TrRestitusi()
        {
            TrHutangP = new HashSet<TrHutangP>();
        }

        public int IdTrRestitusi { get; set; }
        public string Npp { get; set; }
        public int? IdRefRestitusi { get; set; }
        public string IdKeluarga { get; set; }
        public DateTime? TglKuitansi { get; set; }
        public decimal? NominalKuitansi { get; set; }
        public DateTime? TglAmbil { get; set; }
        public decimal? Nominal { get; set; }
        public string Keterangan { get; set; }
        public bool? Status { get; set; }
        public int? IdMstRekanan { get; set; }
        public DateTime? TglCair { get; set; }
        public bool? IsSubsidi { get; set; }
        public decimal? NominalSubsidi { get; set; }
        public decimal? NominalHutang { get; set; }
        public string NomorFpd { get; set; }
        public decimal? SaldoBulanIni { get; set; }
        public decimal? SaldoBulanDepan { get; set; }
        public decimal? BulanDepan { get; set; }
        public decimal? BulanIni { get; set; }
        public int? XAngsur { get; set; }
        public int? SudahAngsur { get; set; }
        public decimal? JmlAngsuran { get; set; }
        public DateTime? MulaiAngsur { get; set; }
        public DateTime? TglLunas { get; set; }
        public string CaraBayar { get; set; }
        public string NoSurat { get; set; }
        public decimal? NominalGabungHutang { get; set; }
        public string IdTrRestitusiGabung { get; set; }
        public bool? IsGabung { get; set; }
        public DateTime? TglInput { get; set; }

        //public TrRestitusi IdTrRestitusiNavigation { get; set; }
      //  public TrRestitusi InverseIdTrRestitusiNavigation { get; set; }
            public MstKaryawan NppNavigation { get; set; }
      
            public MstRekanan idRekanantNavigation { get; set; }
        public ICollection<TrHutangP> TrHutangP { get; set; }
    }
}
