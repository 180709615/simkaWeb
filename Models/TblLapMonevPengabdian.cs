using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblLapMonevPengabdian
    {
        public int IdMonev { get; set; }
        public int IdProposal { get; set; }
        public string Npp { get; set; }
        public int NoUpdate { get; set; }
        public DateTime? TanggalUpload { get; set; }
        public byte[] Keterangan { get; set; }
    }
}
