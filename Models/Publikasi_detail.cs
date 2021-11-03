using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{

    public class Publikasi_detail
    {
        public string? id { get; set; }
        public string? kategori_kegiatan { get; set; }
        public string? judul { get; set; }
        public int? quartile { get; set; }
        public string? jenis_publikasi { get; set; }
        public string? tanggal { get; set; }
        public int? id_kategori_kegiatan { get; set; }
        public int? id_jenis_publikasi { get; set; }
        public string? kategori_capaian_luaran { get; set; }
        public int ?id_kategori_capaian_luaran { get; set; }
        public string? judul_litabmas { get; set; }
        public string? id_litabmas { get; set; }
        public string? nomor_paten { get; set; }
        public string? pemberi_paten { get; set; }
        public string? penerbit { get; set; }
        public string? isbn { get; set; }
        public int? jumlah_halaman { get; set; }
        public string? tautan { get; set; }
        public string? keterangan { get; set; }
        public Penulis[] penulis { get; set; }
        public Dokumen[] dokumen { get; set; }
        public string? judul_artikel { get; set; }
        public string? judul_asli { get; set; }
        public string? nama_jurnal { get; set; }
        public string? halaman { get; set; }
        public string? edisi { get; set; }
        public int? volume { get; set; }
        public int? nomor { get; set; }
        public string? doi { get; set; }
        public string? issn { get; set; }
        public string? e_issn { get; set; }
        public bool seminar { get; set; }
        public bool prosiding { get; set; }
        public string? asal_data { get; set; }

        public string? message { get; set; }

        public string? detail { get; set; }
    }

    public class Penulis
    {
        public string? nama { get; set; }
        public string? jenis { get; set; }
        public string? id_sdm { get; set; }
        public string? id_peserta_didik { get; set; }
        public string? nomor_induk_peserta_didik { get; set; }
        public string? id_orang { get; set; }
        public int? urutan { get; set; }
        public string? afiliasi { get; set; }
        public bool? corresponding_author { get; set; }
        public string? peran { get; set; }
    }

    public class Dokumen
    {
        public string? id { get; set; }
        public string? nama { get; set; }
        public string? jenis_dokumen { get; set; }
        public string? nama_file { get; set; }
        public string? jenis_file { get; set; }
        public string? tanggal_upload { get; set; }
        public string? tautan { get; set; }
        public string? keterangan { get; set; }
    }

}

