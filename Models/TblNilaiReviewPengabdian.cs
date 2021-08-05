using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblNilaiReviewPengabdian
    {
        public int IdNilaiReview { get; set; }
        public int IdProposal { get; set; }
        public string IdReviewer { get; set; }
        public int CountRevisi { get; set; }
        public int? Skor1 { get; set; }
        public int? Skor2 { get; set; }
        public int? Skor3 { get; set; }
        public int? Skor4 { get; set; }
        public int? Skor5 { get; set; }
        public int? Skor6 { get; set; }
        public string Justifikasi1 { get; set; }
        public string Justifikasi2 { get; set; }
        public string Justifikasi3 { get; set; }
        public string Justifikasi4 { get; set; }
        public string Justifikasi5 { get; set; }
        public string Justifikasi6 { get; set; }
        public string Catatan1 { get; set; }
        public string Catatan2 { get; set; }
        public string Catatan3 { get; set; }
        public string Catatan4 { get; set; }
        public string Catatan5 { get; set; }
        public string Kesimpulan { get; set; }
        public int? Anggaran { get; set; }
        public string AnggaranHuruf { get; set; }
        public string Keunikan { get; set; }
    }
}
