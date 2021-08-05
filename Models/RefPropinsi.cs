using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefPropinsi
    {
        public RefPropinsi()
        {
            RefKabKodya = new HashSet<RefKabKodya>();
            RefSmuSmk = new HashSet<RefSmuSmk>();
            RefUniversitas = new HashSet<RefUniversitas>();
        }

        public int IdRefPropinsi { get; set; }
        public string Deskripsi { get; set; }
        public int? IdRefNegara { get; set; }

        public ICollection<RefKabKodya> RefKabKodya { get; set; }
        public ICollection<RefSmuSmk> RefSmuSmk { get; set; }
        public ICollection<RefUniversitas> RefUniversitas { get; set; }
    }
}
