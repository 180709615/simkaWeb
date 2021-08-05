using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrKegiatan
    {
        public int IdTrKegiatan { get; set; }
        public string Npp { get; set; }
        public int? IdRefKegiatan { get; set; }
        public string NamaKegiatan { get; set; }
        public DateTime? TglMulai { get; set; }
        public DateTime? TglSelesai { get; set; }
        public string Tempat { get; set; }
        public string Peran { get; set; }
        public string Tingkat { get; set; }
        public byte[] FileKegiatan { get; set; }

        public RefKegiatan IdRefKegiatanNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
    }
}
