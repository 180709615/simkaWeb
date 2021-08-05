using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblSumberBiayaSl
    {
        public TblSumberBiayaSl()
        {
            TblBiayaSlEksternal = new HashSet<TblBiayaSlEksternal>();
            TblBiayaSlInternal = new HashSet<TblBiayaSlInternal>();
        }

        public int IdStudiLanjut { get; set; }
        public int? IdSumberBiaya { get; set; }
        public int? SumberBiayaKe { get; set; }
        public int IdSumberBiayaSl { get; set; }

        public TblStudiLanjut IdStudiLanjutNavigation { get; set; }
        public RefSumberBiaya IdSumberBiayaNavigation { get; set; }
        public ICollection<TblBiayaSlEksternal> TblBiayaSlEksternal { get; set; }
        public ICollection<TblBiayaSlInternal> TblBiayaSlInternal { get; set; }
    }
}
