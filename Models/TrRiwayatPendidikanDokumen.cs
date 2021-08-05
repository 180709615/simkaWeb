using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TrRiwayatPendidikanDokumen
    {
        public int IdTrRpDokumen { get; set; }
        public int? IdTrRp { get; set; }
        public byte[] Dokumen { get; set; }
        public string NamaDokumen { get; set; }
        public string Keterangan { get; set; }
        public int? IdJenisDokumen { get; set; }
        public string TautanDokumen { get; set; }

        public RefJenisDokumen IdJenisDokumenNavigation { get; set; }
        public TrRiwayatPendidikan IdTrRpNavigation { get; set; }
    }
}
