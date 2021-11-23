using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class TrPublikasi_DATA_SISTER
    {
        [Key]
        public string id { get; set; }
        public string? kategori_kegiatan { get; set; }
        public string? judul { get; set; }
        public int? quartile { get; set; }
        public string? jenis_publikasi { get; set; }
        public DateTime? tanggal { get; set; }
        public int? id_kategori_kegiatan { get; set; }
        public int? id_jenis_publikasi { get; set; }
        public string? kategori_capaian_luaran { get; set; }
        public int? id_kategori_capaian_luaran { get; set; }
        public string? judul_litabmas { get; set; }
        public string? id_litabmas { get; set; }
        public string? nomor_paten { get; set; }
        public string? pemberi_paten { get; set; }
        public string? penerbit { get; set; }
        public string? isbn { get; set; }
        public int? jumlah_halaman { get; set; }
        public string? tautan { get; set; }
        public string? keterangan { get; set; }        
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
        public int seminar { get; set; }
        public int prosiding { get; set; }
        public string? asal_data { get; set; }
        public byte[]? FILE_PROSIDING_ARTIKEL { get; set; }
        public byte[]? FILE_CEK_SIMILARITAS { get; set; }
        public byte[]? FILE_PEER_REVIEW_PAK { get; set; }
        public byte[]? FILE_PEER_KORESPONDENSI_REVIEWER { get; set; }

            
        // PENULIS
        



    }
}
