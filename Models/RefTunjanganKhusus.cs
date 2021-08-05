using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefTunjanganKhusus
    {
        public RefTunjanganKhusus()
        {
            MstKaryawan = new HashSet<MstKaryawan>();
            MstTarifPayroll = new HashSet<MstTarifPayroll>();
        }

        public int IdRefTunjanganKhusus { get; set; }
        public string Deskripsi { get; set; }

        public ICollection<MstKaryawan> MstKaryawan { get; set; }
        public ICollection<MstTarifPayroll> MstTarifPayroll { get; set; }
    }
}
