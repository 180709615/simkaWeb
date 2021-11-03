using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class ViewPerbandinganPengajaran_SPKP
    {
        public string id_pengajaran { get; set; }
        public string semester { get; set; }
        public string mata_kuliah { get; set; }
        public string kelas { get; set; }
        public float sks { get; set; }
        public string id_semester { get; set; }
        public float sks_tatap_muka { get; set; }
        public float sks_praktik { get; set; }
        public float sks_praktik_lapangan { get; set; }
        public float sks_simulasi { get; set; }
        public int tatap_muka_rencana { get; set; }
        public int tatap_muka_realisasi { get; set; }
        public int jumlah_mahasiswa { get; set; }
        public string jenis_evaluasi { get; set; }
        public string nama_substansi { get; set; }
        public string NPP { get; set; }
        public string NAMA_MK_SPKP { get; set; }
        public string KODE_MK_SPKP { get; set; }
        public string KELAS_SPKP { get; set; }
        public int SKS_SPKP { get; set; }

    }
}



