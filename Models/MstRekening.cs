using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class MstRekening
    {
        public string NoRekening { get; set; }
        public string Npp { get; set; }
        public string NamaBank { get; set; }
        public string StatusRekening { get; set; }
        public string Status { get; set; }

        public MstKaryawan NppNavigation { get; set; }
    }
}
