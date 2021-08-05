using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblDetailHonor
    {
        public int IdTblDetailHonor { get; set; }
        public int? IdMstTarifPayroll { get; set; }
        public int? IdTrHonor { get; set; }
        public decimal? Kuantitas { get; set; }
        public decimal? Nominal { get; set; }

        public MstTarifPayroll IdMstTarifPayrollNavigation { get; set; }
        public TrHonor IdTrHonorNavigation { get; set; }
    }
}
