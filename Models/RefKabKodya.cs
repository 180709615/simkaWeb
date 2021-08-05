using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefKabKodya
    {
        public RefKabKodya()
        {
            RefKecamatan = new HashSet<RefKecamatan>();
            RefSmuSmk = new HashSet<RefSmuSmk>();
            RefUniversitas = new HashSet<RefUniversitas>();
        }

        public int IdRefKabKodya { get; set; }
        public int? IdRefPropinsi { get; set; }
        public string Deskripsi { get; set; }

        public RefPropinsi IdRefPropinsiNavigation { get; set; }
        public ICollection<RefKecamatan> RefKecamatan { get; set; }
        public ICollection<RefSmuSmk> RefSmuSmk { get; set; }
        public ICollection<RefUniversitas> RefUniversitas { get; set; }
    }
}
