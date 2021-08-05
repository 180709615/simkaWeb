using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblPengabdianLolos
    {
        public int IdProposal { get; set; }
        public string Npp { get; set; }
        public int IdSumber { get; set; }
        public int IdTahunAnggaran { get; set; }
        public string Reviewer1 { get; set; }
        public string Reviewer2 { get; set; }
        public string JudulKegiatan { get; set; }
        public string LandasanPenelitian { get; set; }
        public string JenisPengabdian { get; set; }
        public string Anggota1 { get; set; }
        public string Anggota1Keahlian { get; set; }
        public string Anggota2 { get; set; }
        public string Anggota2Keahlian { get; set; }
        public string Mitra { get; set; }
        public string MitraKeahlian { get; set; }
        public string Lokasi { get; set; }
        public double? JarakPtLokasi { get; set; }
        public string Output { get; set; }
        public string Outcome { get; set; }
        public DateTime? Awal { get; set; }
        public DateTime? Akhir { get; set; }
        public string Sasaran { get; set; }
        public int? SksKetua { get; set; }
        public int? SksAnggota { get; set; }
        public int? IdRoadMap { get; set; }
        public int? DanaUajy { get; set; }
        public int? DanaPribadi { get; set; }
        public byte[] Dokumen { get; set; }
        public bool? IsDropped { get; set; }
        public int? IdStatus { get; set; }
        public bool? IsChecked { get; set; }
        public bool? IsSetujuProdi { get; set; }
        public bool? IsSetujuDekan { get; set; }
        public bool? IsSetujuLppm { get; set; }
        public string NppReviewer { get; set; }
        public decimal? DanaSetuju { get; set; }
        public decimal? DanaRekomen { get; set; }
        public byte[] Laporan1 { get; set; }
        public byte[] Laporan { get; set; }
        public bool? IsSetujuPustakawan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string IpAddress { get; set; }
        public string UserId { get; set; }
    }
}
