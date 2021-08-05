using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrKarirGolongan
    {
        public string Npp { get; set; }
        public string NoSk { get; set; }
        public string IdRefGolonganLama { get; set; }
        public string IdRefGolonganBaru { get; set; }
        public DateTime? TglBerikut { get; set; }
        public double? Nilai { get; set; }
        public DateTime? Tmt { get; set; }
        public float? NilaiA { get; set; }
        public float? NilaiB { get; set; }
        public float? NilaiC { get; set; }
        public float? NilaiD { get; set; }
        public string JenisLokalNas { get; set; }
        public bool? IsLast { get; set; }
        public int? MasaKerjaGol { get; set; }
        public int IdTrKarirGolongan { get; set; }
        public DateTime? DateInserted { get; set; }

        public MstKaryawan NppNavigation { get; set; }
    }
}
