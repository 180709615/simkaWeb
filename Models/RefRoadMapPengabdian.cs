using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefRoadMapPengabdian
    {
        public int IdRoadMapPengabdian { get; set; }
        public int IdUnitAkademik { get; set; }
        public string Deskripsi { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
