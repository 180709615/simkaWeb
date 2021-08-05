using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblAppraisal
    {
        public string Npp { get; set; }
        public int? IdRefJnsAppraisal { get; set; }
        public DateTime? TglAppraisal { get; set; }
        public float? NilaiTotal { get; set; }
        public int IdAppraisal { get; set; }

        public RefJenisAppraisal IdRefJnsAppraisalNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
    }
}
