using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrMember
    {
        public string Npp { get; set; }
        public int IdTrPengembangan { get; set; }
        public string Peran { get; set; }

        public TrPengembangan IdTrPengembanganNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
    }
}
