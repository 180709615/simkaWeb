using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblDetailPayrollPiutang
    {
        public int IdTblDetailPayrollPiutang { get; set; }
        public int? IdTrPayroll { get; set; }
        public int? IdRefPiutang { get; set; }
        public decimal? Kuantitas { get; set; }
        public decimal? Nominal { get; set; }

        public RefPiutang IdRefPiutangNavigation { get; set; }
        public TrPayroll IdTrPayrollNavigation { get; set; }
    }
}
