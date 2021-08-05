using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefDp3
    {
        public RefDp3()
        {
            TblDetailDp3 = new HashSet<TblDetailDp3>();
        }

        public int IdRefDp3 { get; set; }
        public string Deskripsi { get; set; }

        public ICollection<TblDetailDp3> TblDetailDp3 { get; set; }
    }
}
