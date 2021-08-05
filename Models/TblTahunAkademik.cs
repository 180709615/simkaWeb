using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblTahunAkademik
    {
        public TblTahunAkademik()
        {
            TblSemesterAkademik = new HashSet<TblSemesterAkademik>();
        }

        public int IdTahunAkademik { get; set; }
        public string TahunAkademik { get; set; }
        public int? Tahun { get; set; }
        public bool? Iscurrent { get; set; }

        public ICollection<TblSemesterAkademik> TblSemesterAkademik { get; set; }
    }
}
