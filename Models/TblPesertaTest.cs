using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblPesertaTest
    {
        public int? IdJenisTest { get; set; }
        public DateTime? TglTest { get; set; }
        public string TotalNilai { get; set; }
        public int IdCalonKaryawan { get; set; }

        public TblCalonKaryawan IdCalonKaryawanNavigation { get; set; }
        public RefJenisTest IdJenisTestNavigation { get; set; }
    }
}
