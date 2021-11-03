using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{

    
    public class Penelitian_Detail
    {
        public string? id { get; set; }
        public int? id_kategori_kegiatan { get; set; }
        public string? judul { get; set; }
        public int? lama_kegiatan { get; set; }
        public int? tahun_pelaksanaan_ke { get; set; }
        public decimal? dana_dikti { get; set; }
        public decimal? dana_perguruan_tinggi { get; set; }
        public decimal? dana_institusi_lain { get; set; }
        public string? in_kind { get; set; }
        public string? sk_penugasan { get; set; }
        public DateTime? tanggal_sk_penugasan { get; set; }
        public string? lokasi { get; set; }
        public string? id_jenis_skim { get; set; }
        public string? jenis_skim { get; set; }
        public int? tahun_usulan { get; set; }
        public int? tahun_kegiatan { get; set; }
        public int? tahun_pelaksanaan { get; set; }
        public string? id_litabmas_sebelumnya { get; set; }
        public string? litabmas_sebelumnya { get; set; }
        public string? id_afiliasi { get; set; }
        public string? afiliasi { get; set; }
        public string? id_kelompok_bidang { get; set; }
        public string? kelompok_bidang { get; set; }
        public Anggota[] anggota { get; set; }
        public Dokumen[] dokumen { get; set; }
        public Mitra_Litabmas[] mitra_litabmas { get; set; }

        public string? message { get; set; }

        public string? detail { get; set; }


    }

    public class Anggota
    {
        public string? jenis { get; set; }
        public string? nama { get; set; }
        public string? nipd { get; set; }
        public string? peran { get; set; }
        public string id_sdm { get; set; }
        public string? id_orang { get; set; }
        public string? id_pd { get; set; }
        public bool? stat_aktif { get; set; }
    }

    

    public class Mitra_Litabmas
    {
        public string? id { get; set; }
        public string? nama { get; set; }
    }



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
