using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class MstUnitAkademik
    {
        public string Jenjang { get; set; }
        public string Gelar { get; set; }
        public string SingkatanGelar { get; set; }
        public string KodeUaDikti { get; set; }
        public int IdUnit { get; set; }
        public string Alamat { get; set; }
        public string NoTelp { get; set; }
        public string NoFax { get; set; }
        public int? MstIdUnit { get; set; }
        public string KodeUnitAkademik { get; set; }
        public string NamaUnitAkademik { get; set; }
        public string JenisUnitAkademik { get; set; }

        public MstUnit IdUnitNavigation { get; set; }
        public ICollection<MstKaryawan> MstKaryawanMstIdUnitAkademikNavigation { get; set; }
    }
}
