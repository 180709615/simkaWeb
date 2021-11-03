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


        public string id { get; set; }
        public string kategori_kegiatan { get; set; }
        public string judul { get; set; }
        public int? quartile { get; set; }
        public string jenis_publikasi { get; set; }
        public string tanggal { get; set; }
        public string asal_data { get; set; }

        public string? message { get; set; }

        public string? detail { get; set; }


    }

    public class Publikasis
    {
        public string id_riwayat_publikasi_paten { get; set; }
        public string judul_publikasi_paten { get; set; }
        public string nama_jenis_publikasi { get; set; }
        public string tanggal_terbit { get; set; }
    }

}
