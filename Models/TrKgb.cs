using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrKgb
    {
        public int IdTrKgb { get; set; }
        public string Npp { get; set; }
        public DateTime? TglKenaikan { get; set; }
        public DateTime? TglKenaikanBerikutnya { get; set; }
        public string NoSk { get; set; }
        public decimal? GajiAwal { get; set; }
        public decimal? GajiBerikutnya { get; set; }

        public HstSk NoSkNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
    }
}
