using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class DtlRabPenelitian
    {
        public int IdDtlRabPenelitian { get; set; }
        public int? IdRabPenelitian { get; set; }
        public decimal? JumlahDana { get; set; }
        public int? Jumlah { get; set; }
        public string Satuan { get; set; }
        public decimal? HargaSatuan { get; set; }
        public string Keterangan { get; set; }

        public TblRabPenelitian IdRabPenelitianNavigation { get; set; }
    }
}
