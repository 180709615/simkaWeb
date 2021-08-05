using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefPotonganP
    {
        public RefPotonganP()
        {
            TblDetailPayrollPotongan = new HashSet<TblDetailPayrollPotongan>();
            TrHutangP = new HashSet<TrHutangP>();
        }

        public int IdRefPotongan { get; set; }
        public string NamaPotongan { get; set; }
        public decimal? Nominal { get; set; }
        public bool? IsTetap { get; set; }

        public ICollection<TblDetailPayrollPotongan> TblDetailPayrollPotongan { get; set; }
        public ICollection<TrHutangP> TrHutangP { get; set; }
    }
}
