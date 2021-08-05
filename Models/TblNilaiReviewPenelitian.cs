using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblNilaiReviewPenelitian
    {
        public int IdNilaiReview { get; set; }
        public int IdProposal { get; set; }
        public string IdReviewer { get; set; }
        public int CountRevisi { get; set; }
        public double? N1Field1 { get; set; }
        public double? N1Field2 { get; set; }
        public double? N1Field3 { get; set; }
        public double? N1Field4 { get; set; }
        public double? N1Field5 { get; set; }
        public double? N1Field6 { get; set; }
        public double? N1Field7 { get; set; }
        public string N1Justifikasi1 { get; set; }
        public string N1Justifikasi2 { get; set; }
        public string N1Justifikasi3 { get; set; }
        public string N1Justifikasi4 { get; set; }
        public string N1Justifikasi5 { get; set; }
        public string N1Justifikasi6 { get; set; }
        public string N1Justifikasi7 { get; set; }
        public int? DanaRekomendasi { get; set; }
        public int? DanaSetuju { get; set; }
    }
}
