using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefStatusHutang
    {
        public RefStatusHutang()
        {
            TblDetailHutang = new HashSet<TblDetailHutang>();
        }

        public int IdRefStatusHutang { get; set; }
        public string Deskripsi { get; set; }

        public ICollection<TblDetailHutang> TblDetailHutang { get; set; }
    }
}
