using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class TrPublikasi_DATA_SISTER
    {
        public string id_riwayat_publikasi_paten { get; set; }
        public string? judul_publikasi_paten { get; set; }
        public string judul_asli_tulisan { get; set; }
        public string? tautan_laman_jurnal { get; set; }

        [DataType(DataType.Date)]
        public DateTime tanggal_terbit { get; set; }
        public int? volume { get; set; }
        public int? nomor_hasil_publikasi { get; set; }
        public string? halaman { get; set; }
        public int? jumlah_halaman { get; set; }
        public string? nama_penerbit { get; set; }
        public string? DOI_publikasi { get; set; }
        public string? ISBN_bahan_ajar { get; set; }
        public string? ISSN_publikasi { get; set; }
        public string? tautan { get; set; }
        public string? keterangan { get; set; }
        public string? pengguna_produk_jasa { get; set; }
        public int? a_komersialisasi { get; set; }
        public string? stat_impor_sinta { get; set; }
        public string? quartile { get; set; }
        public DateTime? tgl_create { get; set; }
        public string? nama_kategori_kegiatan { get; set; }
        public string? nama_jenis_publikasi { get; set; }
        public string? nama_kategori_pencapaian { get; set; }
        public string? judul_penelitian_pengabdian { get; set; }
        public string NPP { get; set; }

    }
}
