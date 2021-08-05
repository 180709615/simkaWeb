using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class GabungListSk
    {
        public List<MstKaryawan> karyawans { get; set; }
        public string NoSk { get; set; }
        public string Npp { get; set; }
        [Required]
        public string Peran { get; set; }

        public int? IdUnit { get; set; }
        public int? IdJabatan { get; set; }
        [Required]
        public DateTime? TglAwal { get; set; }
        [Required]
        public DateTime? TglAkhir { get; set; }
    
}
}
