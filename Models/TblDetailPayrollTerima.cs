using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblDetailPayrollTerima
    {
        public int IdTblDetailPayrollTerima { get; set; }
        public int? IdTrPayroll { get; set; }
        public decimal? Kuantitas { get; set; }
        public decimal? Nominal { get; set; }
        public int? IdMstTarifPayroll { get; set; }

        public TrPayroll IdTrPayrollNavigation { get; set; }
    }
}
