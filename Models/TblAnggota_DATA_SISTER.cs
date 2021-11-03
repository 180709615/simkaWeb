using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class TblAnggota_DATA_SISTER
    {
        public int? no { get; set; }
        public string? jenis { get; set; }
        public string? nama { get; set; }
        public string? nipd { get; set; }
        public string? peran { get; set; }
        public string id_sdm { get; set; }
        public string? id_orang { get; set; }
        public string? id_pd { get; set; }
        public int? stat_aktif { get; set; }
        public string? id_penelitian_pengabdian{ get; set; }
    }
}
