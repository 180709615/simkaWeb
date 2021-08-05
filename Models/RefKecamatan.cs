using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefKecamatan
    {
        public RefKecamatan()
        {
            RefKelurahan = new HashSet<RefKelurahan>();
        }

        public int IdRefKecamatan { get; set; }
        public int? IdRefKabKodya { get; set; }
        public string Deskripsi { get; set; }

        public RefKabKodya IdRefKabKodyaNavigation { get; set; }
        public ICollection<RefKelurahan> RefKelurahan { get; set; }
    }
}
