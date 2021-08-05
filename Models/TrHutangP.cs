using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrHutangP
    {
        public TrHutangP()
        {
            TblDetailHutang = new HashSet<TblDetailHutang>();
        }

        public int IdTrHutang { get; set; }
        public string Npp { get; set; }
        public int? IdRefPotongan { get; set; }
        public decimal? Nominal { get; set; }
        public int? Cicilan { get; set; }
        public decimal? BesarCicilan { get; set; }
        public float? Bunga { get; set; }
        public decimal? SisaNominal { get; set; }
        public DateTime? BulanMulaiBayar { get; set; }
        public int? IdTrRestitusi { get; set; }
        public decimal? NominalDp { get; set; }
        public int? CicilanDp { get; set; }

        public RefPotonganP IdRefPotonganNavigation { get; set; }
        public TrRestitusi IdTrRestitusiNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
        public ICollection<TblDetailHutang> TblDetailHutang { get; set; }
    }
}
