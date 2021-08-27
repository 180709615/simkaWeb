using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{

    public class Penelitian_Detail
    {
        public int error_code { get; set; }
        public string error_desc { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string? id_penelitian_pengabdian { get; set; }
        public string? judul_penelitian_pengabdian { get; set; }
        public int? durasi_kegiatan { get; set; }
        public int? tahun_pelaksanaan_ke { get; set; }
        public string? dana_dari_dikti { get; set; }
        public string? dana_dari_PT { get; set; }
        public string? dana_dari_instansi_lain { get; set; }
        public string? in_kind { get; set; }
        public string? status_aktif { get; set; }
        public string? no_sk_tugas { get; set; }
        public string? tanggal_sk_penugasan { get; set; }
        public string? tempat_kegiatan { get; set; }
        public string? nama_skim { get; set; }
        public string? nama_tahun_anggaran { get; set; }
        public string? parent_judul_litabmas { get; set; }
        public string? nama_lembaga { get; set; }
        public string? nama_kelompok_bidang { get; set; }
    }

}
