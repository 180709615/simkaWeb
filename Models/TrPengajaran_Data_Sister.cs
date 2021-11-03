using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class TrPengajaran_Data_SISTER
    {
        public string? id { get; set; }
        public string? semester { get; set; }
        public string? mata_kuliah { get; set; }
        public string? kelas { get; set; }
        public decimal? sks { get; set; }
        public string? id_semester { get; set; }
        public decimal? sks_tatap_muka { get; set; }
        public decimal? sks_praktik { get; set; }
        public decimal? sks_praktik_lapangan { get; set; }
        public decimal? sks_simulasi { get; set; }
        public int? tatap_muka_rencana { get; set; }
        public int? tatap_muka_realisasi { get; set; }
        public int? jumlah_mahasiswa { get; set; }
        public string? jenis_evaluasi { get; set; }

        public string? nama_substansi { get; set; }
        public string? NPP { get; set; }
    }
}
