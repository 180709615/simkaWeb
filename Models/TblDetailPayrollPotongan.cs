using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblDetailPayrollPotongan
    {
        public int IdPayrollPotongan { get; set; }
        public int? IdTrPayroll { get; set; }
        public int? IdRefPotongan { get; set; }
        public decimal? Kuantitas { get; set; }
        public decimal? Nominal { get; set; }

        public RefPotonganP IdRefPotonganNavigation { get; set; }
        public TrPayroll IdTrPayrollNavigation { get; set; }
    }
}
