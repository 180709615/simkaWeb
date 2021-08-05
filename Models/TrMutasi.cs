using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrMutasi
    {
        public int IdTrMutasi { get; set; }
        public string Npp { get; set; }
        public int? IdUnit { get; set; }
        public string NoSk { get; set; }
        public int? MstIdUnit { get; set; }

        public MstUnit IdUnitNavigation { get; set; }
        public MstUnit MstIdUnitNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
    }
}
