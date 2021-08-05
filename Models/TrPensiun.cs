using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrPensiun
    {
        public int IdTrPensiun { get; set; }
        public string Npp { get; set; }
        public string NoSk { get; set; }
        public string GolTerakhir { get; set; }
        public decimal? GajiAkhirPensiun { get; set; }
        public DateTime? TanggalPensiun { get; set; }

        public HstSk NoSkNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
    }
}
