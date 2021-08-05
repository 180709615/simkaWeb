using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblDetailHutang
    {
        public int IdTblDetailHutang { get; set; }
        public int? CicilanKe { get; set; }
        public int? IdTrHutang { get; set; }
        public decimal? Nominal { get; set; }
        public DateTime? TglBayar { get; set; }
        public int? IdRefStatusHutang { get; set; }
        public bool? IsDp { get; set; }
        public bool? Approval { get; set; }
        public DateTime? TglApproval { get; set; }
        public DateTime? TglInput { get; set; }

        public RefStatusHutang IdRefStatusHutangNavigation { get; set; }
        public TrHutangP IdTrHutangNavigation { get; set; }
    }
}
