using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public partial class TrPenelitian_DATA_SISTER
    {
        [Key]
        public string? id_penelitian_pengabdian { get; set; }
        public int? id_kategori_kegiatan { get; set; }
        public string? judul_penelitian_pengabdian { get; set; }
        public int? durasi_kegiatan { get; set; }
        public int? tahun_pelaksanaan_ke { get; set; }
        public decimal? dana_dari_dikti { get; set; }
        public decimal? dana_dari_PT { get; set; }
        public decimal? dana_dari_instansi_lain { get; set; }
        public string? in_kind { get; set; }
        public string? status_aktif { get; set; }
        public string? no_sk_tugas { get; set; }
        public DateTime? tanggal_sk_penugasan { get; set; }
        public string? tempat_kegiatan { get; set; }
        public string? id_jenis_skim { get; set; }
        public string? jenis_skim{ get; set; }
      
        public string? nama_lembaga { get; set; }
        public int? tahun_usulan { get; set; }
        public int? tahun_kegiatan { get; set; }
        public int? tahun_pelaksanaan { get; set; }
        public string? id_litabmas_sebelumnya { get; set; }
        public string? litabmas_sebelumnya { get; set; }
        public string? id_afiliasi { get; set; }
        public string? afiliasi { get; set; }
        public string? id_kelompok_bidang { get; set; }
        public string? nama_kelompok_bidang { get; set; }        
        public string NPP1 { get; set; }
        public string? NPP2 { get; set; }
        public string? NPP3 { get; set; }
        public string? NPP4 { get; set; }
        public string? NPP5 { get; set; }
        public string? NPP6 { get; set; }

        
    }
}
