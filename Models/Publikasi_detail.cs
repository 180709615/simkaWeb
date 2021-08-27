using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{

    public class Publikasi_detail
    {
        public int error_code { get; set; }
        public string error_desc { get; set; }
        public Publikasi_detail_data data { get; set; }
    }

    public class Publikasi_detail_data
    {
        public string? id_riwayat_publikasi_paten { get; set; }
        public string? judul_publikasi_paten { get; set; }
        public string? judul_asli_tulisan { get; set; }
        public string? tautan_laman_jurnal { get; set; }
        public string? tanggal_terbit { get; set; }
        public string? volume { get; set; }
        public string? nomor_hasil_publikasi { get; set; }
        public string? halaman { get; set; }
        public string? jumlah_halaman { get; set; }
        public string? nama_penerbit { get; set; }
        public string? DOI_publikasi { get; set; }
        public string? ISBN_bahan_ajar { get; set; }
        public string? ISSN_publikasi { get; set; }
        public string? tautan { get; set; }
        public string? keterangan { get; set; }
        public string? pengguna_produk_jasa { get; set; }
        public string? a_komersialisasi { get; set; }
        public string? stat_impor_sinta { get; set; }
        public string? quartile { get; set; }
        public string? tgl_create { get; set; }
        public string? nama_kategori_kegiatan { get; set; }
        public string? nama_jenis_publikasi { get; set; }
        public string? nama_kategori_pencapaian { get; set; }
        public string? judul_penelitian_pengabdian { get; set; }
        public Data_Penulis[]? data_penulis { get; set; }
        public File_Publikasi[]? files { get; set; }
    }

    public class Data_Penulis
    {
        public string? nama { get; set; }
        public string? no_urut { get; set; }
        public string? afiliasi_penulis { get; set; }
        public string? peran_dalam_kegiatan { get; set; }
        public string? jenis_peranan { get; set; }
        public string? apakah_corresponding_author { get; set; }
        public string? id_dosen { get; set; }
        public string? id_mahasiswa_anggota_penelitian_pengabdian { get; set; }
        public string? id_kolaborator_eksternal { get; set; }
        public string? nim { get; set; }
    }

    public class File_Publikasi
    {
        public string? id_dokumen { get; set; }
        public string? nama_dokumen { get; set; }
        public string? nama_file { get; set; }
        public string? jenis_file { get; set; }
        public string? tanggal_upload { get; set; }
        public string? nama_jenis_dokumen { get; set; }
        public string? tautan { get; set; }
        public string? keterangan_dokumen { get; set; }
    }

}
