
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class SimkaDosenPenelitian
    {

        public MstKaryawan Karyawan { get; set; }
        public MstUnitAkademik Akademik { get; set; }
        public ICollection<TblPengabdian> Pengabdian { get; set; }
        public Sister_DosenPenelitian Sister { get; set; }
        public ICollection<TblPenelitian>  Penelitian { get; set; }
        public ICollection<TrPengembangan> Pengembangan{ get; set; }

        public ICollection<TrPenelitian_DATA_SISTER> Penelitian_Sister { get; set; }

        public List<object> semester { get; set; }

    }
}
