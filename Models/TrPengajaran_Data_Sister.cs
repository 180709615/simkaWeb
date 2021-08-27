using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class TrPengajaran_Data_SISTER
    {
        public string id_pembelajaran { get; set; }
        public Decimal? sks_total_persubstansi { get; set; }
        public Decimal? sks_tatap_muka_persubstansi { get; set; }
        public Decimal? sks_praktek_persubstansi { get; set; }
        public Decimal? sks_praktek_lapangan_persubstansi { get; set; }
        public Decimal? sks_simulasi_persubstansi { get; set; }
        public int? jumlah_tim_rencana { get; set; }
        public int? jumlah_tim_real { get; set; }
        public int? jumlah_mahasiswa { get; set; }
        public string? nama_kelas_kuliah { get; set; }
        public string? nama_jenis_evaluasi { get; set; }
        public string? nama_substansi { get; set; }

        public string NPP { get; set; }

        public string nama_mata_kuliah { get; set; }
    }
}
