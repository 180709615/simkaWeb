using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{

    public class Pengajaran_detail
    {
        public int error_code { get; set; }
        public string error_desc { get; set; }
        public Pengajaran_Detail_data data { get; set; }
    }

    public class Pengajaran_Detail_data
    {
        public string? id_pembelajaran { get; set; }
        public string? sks_total_persubstansi { get; set; }
        public string? sks_tatap_muka_persubstansi { get; set; }
        public string? sks_praktek_persubstansi { get; set; }
        public string? sks_praktek_lapangan_persubstansi { get; set; }
        public string? sks_simulasi_persubstansi { get; set; }
        public string? jumlah_tim_rencana { get; set; }
        public string? jumlah_tim_real { get; set; }
        public string? jumlah_mahasiswa { get; set; }
        public string? nama_kelas_kuliah { get; set; }
        public string? nama_jenis_evaluasi { get; set; }
        public string? nama_substansi { get; set; }
    }
}

