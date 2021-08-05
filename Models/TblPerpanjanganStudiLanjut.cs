using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblPerpanjanganStudiLanjut
    {
        public int IdPerpanjanganStudiLanjut { get; set; }
        public int? IdStudiLanjut { get; set; }
        public DateTime? TglPerpanjangan { get; set; }
        public int? PerpanjanganKe { get; set; }
        public bool? IsApproved { get; set; }
        public byte[] SkPerpanjangan { get; set; }

        public TblStudiLanjut IdStudiLanjutNavigation { get; set; }
    }
}
