using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblPenelitian
    {
        public int IdProposal { get; set; }
        public int IdTahunAnggaran { get; set; }
        public int? NoSemester { get; set; }
        public int IdKategori { get; set; }
        public int? IdRoadMapPenelitian { get; set; }
        public int? IdSkim { get; set; }
        public int? IdTemaUniversitas { get; set; }
        public int? IdStatusPenelitian { get; set; }
        public string Jenis { get; set; }
        public string Judul { get; set; }
        public string Lokasi { get; set; }
        public string Npp { get; set; }
        public string Npp1 { get; set; }
        public string Npp2 { get; set; }
        public DateTime? Awal { get; set; }
        public DateTime? Akhir { get; set; }
        public bool IsChecked { get; set; }
        public string NppReviewer { get; set; }
        public string Reviewer1 { get; set; }
        public string Reviewer2 { get; set; }
        public int? BebanSks { get; set; }
        public int? BebanSksAnggota { get; set; }
        public decimal? DanaUsul { get; set; }
        public decimal? DanaPribadi { get; set; }
        public decimal? DanaEksternal { get; set; }
        public decimal? DanaKerjasama { get; set; }
        public decimal? DanaUajy { get; set; }
        public decimal? DanaSetuju { get; set; }
        public byte[] Dokumen { get; set; }
        public byte[] LembarPengesahan { get; set; }
        public string Keyword { get; set; }
        public double? JarakKampusKm { get; set; }
        public int? JarakKampusJam { get; set; }
        public string Outcome { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool? IsSetujuProdi { get; set; }
        public bool? IsSetujuDekan { get; set; }
        public bool? IsSetujuLppm { get; set; }
        public bool? IsDropped { get; set; }
        public DateTime? InsertDate { get; set; }
        public string IpAddress { get; set; }
        public string UserId { get; set; }
        public bool? IsLock { get; set; }
        public string KeteranganDanaEksternal { get; set; }
    }
}
