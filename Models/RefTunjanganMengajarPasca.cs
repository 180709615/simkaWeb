using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefTunjanganMengajarPasca
    {
        public RefTunjanganMengajarPasca()
        {
            MstTarifPayroll = new HashSet<MstTarifPayroll>();
        }

        public int IdRefTunjanganPasca { get; set; }
        public string Deskripsi { get; set; }
        public string Prodi { get; set; }

        public ICollection<MstTarifPayroll> MstTarifPayroll { get; set; }
    }
}
