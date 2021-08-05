using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblUsulanRekrutmen
    {
        public int IdMstUr { get; set; }
        public int? IdUnit { get; set; }
        public int? NoSemester { get; set; }
        public int? IdTahunAkademik { get; set; }
        public string SpesikasiAkademik { get; set; }
        public int? UmurMax { get; set; }
        public string SpesifikasiKetrampilan { get; set; }
        public int? Jumlah { get; set; }
        public DateTime? TglUsulan { get; set; }
        public string PendidikanTerakhir { get; set; }
        public float? Ipk { get; set; }

        public MstUnit IdUnitNavigation { get; set; }
        public TblUsulanDiterima TblUsulanDiterima { get; set; }
    }
}
