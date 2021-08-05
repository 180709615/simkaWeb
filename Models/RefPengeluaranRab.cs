using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefPengeluaranRab
    {
        public RefPengeluaranRab()
        {
            TblRabPenelitian = new HashSet<TblRabPenelitian>();
            TblRabPengabdian = new HashSet<TblRabPengabdian>();
        }

        public int IdPengeluaranRab { get; set; }
        public string Kategori { get; set; }
        public string Deskripsi { get; set; }
        public decimal? MinPct { get; set; }
        public decimal? MaxPct { get; set; }

        public ICollection<TblRabPenelitian> TblRabPenelitian { get; set; }
        public ICollection<TblRabPengabdian> TblRabPengabdian { get; set; }
    }
}
