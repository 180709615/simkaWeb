using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrHonor
    {
        public TrHonor()
        {
            TblDetailHonor = new HashSet<TblDetailHonor>();
        }

        public string Npp { get; set; }
        public int IdTrHonor { get; set; }
        public decimal? TotalHonor { get; set; }
        public decimal? Pajak { get; set; }

        public MstKaryawan NppNavigation { get; set; }
        public ICollection<TblDetailHonor> TblDetailHonor { get; set; }
    }
}
