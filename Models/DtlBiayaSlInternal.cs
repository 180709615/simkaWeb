using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class DtlBiayaSlInternal
    {
        public int IdDtlBiayaSlInt { get; set; }
        public int? IdBiayaSlInt { get; set; }
        public string Deskripsi { get; set; }
        public string MataUang { get; set; }
        public decimal? Jumlah { get; set; }
        public decimal? Kurs { get; set; }
        public decimal? JumlahRupiah { get; set; }

        public TblBiayaSlInternal IdBiayaSlIntNavigation { get; set; }
    }
}

