using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefKelurahan
    {
        public int IdRefKelurahan { get; set; }
        public int IdRefKecamatan { get; set; }
        public string Deskripsi { get; set; }

        public RefKecamatan IdRefKecamatanNavigation { get; set; }
    }
}
