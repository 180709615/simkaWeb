using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefTunjanganTaKp
    {
        public RefTunjanganTaKp()
        {
            MstTarifPayroll = new HashSet<MstTarifPayroll>();
        }

        public int IdRefTunjanganTaKp { get; set; }
        public string Deskripsi { get; set; }
        public bool? IsInternasional { get; set; }

        public ICollection<MstTarifPayroll> MstTarifPayroll { get; set; }
    }
}
