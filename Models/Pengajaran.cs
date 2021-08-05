using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{

    public class Pengajaran
    {
        public int error_code { get; set; }
        public string error_desc { get; set; }
        public Pengajarans[] data { get; set; }
    }

    public class Pengajarans
    {
        public string id_pembelajaran { get; set; }
        public string jumlah_mahasiswa { get; set; }
        public string nama_kelas_kuliah { get; set; }
        public string id_mk { get; set; }
        public string nama_jenis_evaluasi { get; set; }
        public string nama_substansi { get; set; }
        public string sks_total_persubstansi { get; set; }
        public string nama_mata_kuliah { get; set; }
    }

}
