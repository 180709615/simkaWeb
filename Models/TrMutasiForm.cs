using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIConsume.Models
{
    public partial class TrMutasiForm
    {

        public List<MstUnit> unit { get; set; }
        public List<MstKaryawan> karyawan { get; set; }
        public int IdTrMutasi { get; set; }
        public string Npp { get; set; }
        public int? IdUnit { get; set; }
        [Required]
        public string NoSk { get; set; }
        public int? MstIdUnit { get; set; }

        public MstUnit IdUnitNavigation { get; set; }
        public MstUnit MstIdUnitNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
    }
}
