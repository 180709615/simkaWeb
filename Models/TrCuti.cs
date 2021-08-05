using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrCuti
    {
        public int IdCuti { get; set; }
        public string Npp { get; set; }
        public int? TahunTakwim { get; set; }
        public DateTime TglCutiAwal { get; set; }
        public DateTime TglCutiAkhir { get; set; }
        public bool? IsConfirmed { get; set; }
        public byte[] File { get; set; }
        public string Deskripsi { get; set; }
        public string JenisCuti { get; set; }

        public MstKaryawan NppNavigation { get; set; }
    }
}
