using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefSchedule
    {
        public int IdSchedule { get; set; }
        public DateTime? Awal { get; set; }
        public DateTime? Akhir { get; set; }
        public int? IdTahunAnggaran { get; set; }
        public bool? IsLocked { get; set; }
    }
}
