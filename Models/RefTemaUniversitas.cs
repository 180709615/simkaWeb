using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefTemaUniversitas
    {
        public int IdTemaUniversitas { get; set; }
        public string Kategori { get; set; }
        public string Deskripsi { get; set; }
        public bool? IsCurrent { get; set; }
    }
}
