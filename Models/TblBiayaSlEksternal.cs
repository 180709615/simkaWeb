using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblBiayaSlEksternal
    {
        public int IdBiayaSlEks { get; set; }
        public int? IdSumberBiayaSl { get; set; }
        public DateTime? TglTransfer { get; set; }
        public decimal? Nominal { get; set; }
        public byte[] BuktiTransfer { get; set; }

        public TblSumberBiayaSl IdSumberBiayaSlNavigation { get; set; }
    }
}
