using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblDokumen
    {
        public int IdTblDokumen { get; set; }
        public string Npp { get; set; }
        public int? IdJenisDokumen { get; set; }
        public string NomorDokumen { get; set; }
        public byte[] FileDokumen { get; set; }
        public string Status { get; set; }

        public RefJenisDokumen IdJenisDokumenNavigation { get; set; }
        public MstKaryawan NppNavigation { get; set; }
    }
}
