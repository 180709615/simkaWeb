using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public partial class TrPenelitian_DATA_SISTER
    {
        public string id_penelitian_pengabdian { get; set; }
        public string judul_penelitian_pengabdian { get; set; }
        public int? durasi_kegiatan { get; set; }
        public int? tahun_pelaksanaan_ke { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? dana_dari_dikti { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? dana_dari_PT { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? dana_dari_instansi_lain { get; set; }
        public string? in_kind { get; set; }
        public string? status_aktif { get; set; }
        public string? no_sk_tugas { get; set; }
        public DateTime? tanggal_sk_penugasan { get; set; }
        public string? tempat_kegiatan { get; set; }
        public string? nama_skim { get; set; }
        public string? nama_tahun_anggaran { get; set; }
        public string? parent_judul_litabmas { get; set; }
        public string? nama_lembaga { get; set; }
        public string? nama_kelompok_bidang { get; set; }

        public string NPP { get; set; }

        public string? nama_tahun_ajaran { get; set; }
    }
}
