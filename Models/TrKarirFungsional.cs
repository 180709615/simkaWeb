using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrKarirFungsional
    {
        public int IdKarir { get; set; }
        public string Npp { get; set; }
        public string NoSk { get; set; }
        public int? IdRefJbtnAkademikSblm { get; set; }
        public int? IdRefJbtnAkademik { get; set; }
        public DateTime? TglBerikut { get; set; }
        public float? NilaiTotal { get; set; }
        public DateTime? Tmt { get; set; }
        public float? NilaiA { get; set; }
        public float? NilaiB { get; set; }
        public float? NilaiC { get; set; }
        public float? NilaiD { get; set; }
        public string BidangIlmu { get; set; }
        public string JenisLokalNas { get; set; }
        public bool? IsLast { get; set; }
        public string BidangIlmu2 { get; set; }
        public string BidangIlmu3 { get; set; }

        public RefJabatanAkademik IdRefJbtnAkademikNavigation { get; set; }
        public RefJabatanAkademik IdRefJbtnAkademikSblmNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
    }
}
