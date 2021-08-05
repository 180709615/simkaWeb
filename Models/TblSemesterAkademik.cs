using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblSemesterAkademik
    {
        public int NoSemester { get; set; }
        public string SemesterAkademik { get; set; }
        public string Iscurrent { get; set; }
        public string SemesterAkademikEng { get; set; }
        public int IdTahunAkademik { get; set; }

        public TblTahunAkademik IdTahunAkademikNavigation { get; set; }
    }
}
