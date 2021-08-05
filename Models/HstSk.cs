using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class HstSk
    {
        public HstSk()
        {
            TrKenaikanPangkat = new HashSet<TrKenaikanPangkat>();
            TrKgb = new HashSet<TrKgb>();
            TrPensiun = new HashSet<TrPensiun>();
        }

        public string NoSk { get; set; }
        public int? NoSemester { get; set; }
        public DateTime? TglSk { get; set; }
        public string DeskripsiSk { get; set; }
        public DateTime? TglAwal { get; set; }
        public DateTime? TglAkhir { get; set; }
        public byte[] FileSk { get; set; }
        public int? IdTahunAkademik { get; set; }
        public string LevelSk { get; set; }
        public int? IdRefJenisSk { get; set; }
        public DateTime? DateInserted { get; set; }

        public RefJenisSk IdRefJenisSkNavigation { get; set; }
        public ICollection<TrKenaikanPangkat> TrKenaikanPangkat { get; set; }
        public ICollection<TrKgb> TrKgb { get; set; }
        public ICollection<TrPensiun> TrPensiun { get; set; }
    }
}
