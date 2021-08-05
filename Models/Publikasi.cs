using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{

    public class Publikasi
    {
        public int error_code { get; set; }
        public string error_desc { get; set; }
        public Publikasis[] data { get; set; }
    }

    public class Publikasis
    {
        public string id_riwayat_publikasi_paten { get; set; }
        public string judul_publikasi_paten { get; set; }
        public string nama_jenis_publikasi { get; set; }
        public string tanggal_terbit { get; set; }
    }

}
