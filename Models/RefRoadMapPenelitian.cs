using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefRoadMapPenelitian
    {
        public int IdRoadMapPenelitian { get; set; }
        public int IdUnitAkademik { get; set; }
        public string Deskripsi { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
