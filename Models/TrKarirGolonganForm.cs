using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class TrKarirGolonganForm
    {
        [Required]
        public string Npp { get; set; }
        [Required]
        public string NoSk { get; set; }
        [Required]
        public string IdRefGolonganLama { get; set; }
        public string IdRefGolonganBaru { get; set; }
        [Required]
        public DateTime? TglBerikut { get; set; }
        [Required]
        public double? Nilai { get; set; }
        public DateTime? Tmt { get; set; }
        public float? NilaiA { get; set; }
        public float? NilaiB { get; set; }
        public float? NilaiC { get; set; }
        public float? NilaiD { get; set; }
        [Required]
        public string JenisLokalNas { get; set; }
        public bool? IsLast { get; set; }
        [Required]
        public int? MasaKerjaGol { get; set; }
        public int IdTrKarirGolongan { get; set; }
        public DateTime? DateInserted { get; set; }
        public List<MstKaryawan> karyawan { get; set; }
        public List<RefGolongan> golongan { get; set; }
    }
}
