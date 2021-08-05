using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblUsulanDiterima
    {
        public TblUsulanDiterima()
        {
            TblCalonKaryawan = new HashSet<TblCalonKaryawan>();
        }

        public int IdMstUr { get; set; }
        public string Npp { get; set; }
        public int? Jumlah { get; set; }
        public string TglDisetujui { get; set; }

        public TblUsulanRekrutmen IdMstUrNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
        public ICollection<TblCalonKaryawan> TblCalonKaryawan { get; set; }
    }
}
