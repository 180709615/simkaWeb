using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrKarirStruktural
    {
        
        public string Npp { get; set; }
        public string NoSk { get; set; }
        public int? IdUnit { get; set; }
        public int? MstIdUnit { get; set; }
        public int? IdRefStruktural { get; set; }
        public DateTime? TglAwal { get; set; }  
        public DateTime? TglAkhir { get; set; }
        public string Status { get; set; }
        public int IsLast { get; set; }

      
        public MstUnit IdUnitNavigation { get; set; }     
        public MstKaryawan NppNavigation { get; set; }
        public RefJabatanStruktural IdRefStrukturalNavigation { get; set; }
    }
}
