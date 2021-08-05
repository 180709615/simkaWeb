using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblPenelitianLolos
    {
        public int IdProposal { get; set; }
        public string Npp { get; set; }
        public string Jenis { get; set; }
        public int IdTahunAnggaran { get; set; }
        public bool IsChecked { get; set; }
        public string Reviewer1 { get; set; }
        public string Reviewer2 { get; set; }
        public string Judul { get; set; }
        public int IdKategori { get; set; }
        public string Lokasi { get; set; }
        public int? BebanSks { get; set; }
        public int? IdStatusPenelitian { get; set; }
        public decimal? DanaUsul { get; set; }
        public DateTime? Awal { get; set; }
        public DateTime? Akhir { get; set; }
        public byte[] Dokumen { get; set; }
        public bool? IsDropped { get; set; }
        public string Keyword { get; set; }
        public double? JarakKampusKm { get; set; }
        public int? JarakKampusJam { get; set; }
        public int? IdRoadMapPenelitian { get; set; }
        public string Outcome { get; set; }
        public decimal? DanaPribadi { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Npp1 { get; set; }
        public string Npp2 { get; set; }
        public bool? IsSetujuProdi { get; set; }
        public bool? IsSetujuDekan { get; set; }
        public int? BebanSksAnggota { get; set; }
        public bool? IsSetujuLppm { get; set; }
        public string NppReviewer { get; set; }
        public decimal? DanaSetuju { get; set; }
        public double? Pajak { get; set; }
        public decimal? DanaRekomen { get; set; }
        public byte[] Laporan { get; set; }
        public bool? IsSetujuPustakawan { get; set; }
        public bool? IsSelesai { get; set; }
        public byte[] Laporan1 { get; set; }
        public DateTime? InsertDate { get; set; }
        public string IpAddress { get; set; }
        public string UserId { get; set; }
        public byte[] FileOutcome { get; set; }
    }
}
