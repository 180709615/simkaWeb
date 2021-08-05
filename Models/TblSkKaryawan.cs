using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class TblSkKaryawan
    {
        

        public string NoSk{ get; set; }

        [Required]
        [ConcurrencyCheck]
        public string Npp { get; set; }

        public string Peran { get; set; }
        
        public int? IdUnit { get; set; }
        public int? IdJabatan { get; set; }
        public DateTime? TglAwal { get; set; }
        public DateTime? TglAkhir { get; set; }
        public MstKaryawan NppNavigation { get; set; }
    }
}
