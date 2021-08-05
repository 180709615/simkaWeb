using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrSertifikasi
    {
        public string Npp { get; set; }
        public string NoSertifikasi { get; set; }
        public int? TahunSertifikasi { get; set; }
        public string NoPeserta { get; set; }
        public string NoRegistrasi { get; set; }
        public string PtPenyelenggara { get; set; }
        public byte[] FileSertifikat { get; set; }
        public string BidangIlmu { get; set; }

        public MstKaryawan NppNavigation { get; set; }
    }
}
