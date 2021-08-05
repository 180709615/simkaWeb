using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblTahunAnggaran
    {
        public int IdTahunAnggaran { get; set; }
        public string TahunAnggaran { get; set; }
        public bool? IsCurrent { get; set; }
    }
}
