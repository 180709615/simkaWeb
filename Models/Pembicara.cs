using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{

    public class Pembicara
    {
        public int error_code { get; set; }
        public string error_desc { get; set; }
        public Pembicaras[] data { get; set; }
    }

    public class Pembicaras
    {

    
        public string id_pembicara{ get; set; }
        public string id_induk_katgiat { get; set; }
        public string nama_kategori_kegiatan { get; set; }
        public string judul_makalah{ get; set; }
        public int nama_pertemuan_ilmiah{ get; set; }
        public string penyelenggara_kegiatan{ get; set; }
        public string tanggal_pelaksanaan { get; set; }
    }

}
