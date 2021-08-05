using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefSumberBiaya
    {
        public RefSumberBiaya()
        {
            TblSumberBiayaSl = new HashSet<TblSumberBiayaSl>();
        }

        public int IdSumberBiaya { get; set; }
        public string Deskripsi { get; set; }

        public ICollection<TblSumberBiayaSl> TblSumberBiayaSl { get; set; }
    }
}
