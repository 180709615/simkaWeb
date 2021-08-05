using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefKategori
    {
        public int IdKategori { get; set; }
        public string Kategori { get; set; }
        public string DetailPelaku { get; set; }
        public string DetailBebanSks { get; set; }
        public string Deskripsi { get; set; }
        public bool? IsCurrent { get; set; }
    }
}
