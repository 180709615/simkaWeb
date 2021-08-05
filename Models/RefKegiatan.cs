using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefKegiatan
    {
        public RefKegiatan()
        {
            TrKegiatan = new HashSet<TrKegiatan>();
        }

        public int IdRefKegiatan { get; set; }
        public string Deskripsi { get; set; }

        public ICollection<TrKegiatan> TrKegiatan { get; set; }
    }
}
