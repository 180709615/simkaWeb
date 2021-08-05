using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrDp3
    {
        public int IdTrDp3 { get; set; }
        public string Tahun { get; set; }
        public DateTime? TglPenilaian { get; set; }
        public string Npp { get; set; }
        public decimal? Rerata { get; set; }

        public MstKaryawan NppNavigation { get; set; }
    }
}
