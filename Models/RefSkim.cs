using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefSkim
    {
        public int IdSkim { get; set; }
        public string Kategori { get; set; }
        public string Deskripsi { get; set; }
        public decimal? MaxPagu { get; set; }
    }
}
