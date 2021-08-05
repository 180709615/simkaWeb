using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class DtlRabPengabdian
    {
        public int IdDtlRabPengabdian { get; set; }
        public int? IdRabPengabdian { get; set; }
        public decimal? JumlahDana { get; set; }
        public int? Jumlah { get; set; }
        public string Satuan { get; set; }
        public decimal? HargaSatuan { get; set; }
        public string Keterangan { get; set; }

        public TblRabPengabdian IdRabPengabdianNavigation { get; set; }
    }
}
