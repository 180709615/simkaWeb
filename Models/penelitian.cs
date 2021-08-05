using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{

    public class Penelitian
    {
        public int error_code { get; set; }
        public string error_desc { get; set; }
        public Penelitians[] data { get; set; }
    }

    public class Penelitians
    {
        public string id_penelitian_pengabdian { get; set; }
        public string judul_penelitian_pengabdian { get; set; }
        public string nama_skim { get; set; }
        public string nama_tahun_ajaran { get; set; }
        public int durasi_kegiatan { get; set; }
        public string jenis_penelitian_pengabdian { get; set; }
    }

}
