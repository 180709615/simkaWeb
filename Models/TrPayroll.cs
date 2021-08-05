using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrPayroll
    {
        public TrPayroll()
        {
            TblDetailPayrollPiutang = new HashSet<TblDetailPayrollPiutang>();
            TblDetailPayrollPotongan = new HashSet<TblDetailPayrollPotongan>();
            TblDetailPayrollTerima = new HashSet<TblDetailPayrollTerima>();
        }

        public int IdTrPayroll { get; set; }
        public int? NoSemester { get; set; }
        public string Npp { get; set; }
        public DateTime? Bulan { get; set; }
        public decimal? TotalTerima { get; set; }
        public decimal? TotalPotongan { get; set; }
        public decimal? TotalPiutang { get; set; }
        public decimal? Pajak { get; set; }
        public decimal? TotalBersih { get; set; }

        public MstKaryawan NppNavigation { get; set; }
        public ICollection<TblDetailPayrollPiutang> TblDetailPayrollPiutang { get; set; }
        public ICollection<TblDetailPayrollPotongan> TblDetailPayrollPotongan { get; set; }
        public ICollection<TblDetailPayrollTerima> TblDetailPayrollTerima { get; set; }
    }
}
