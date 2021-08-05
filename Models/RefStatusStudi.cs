using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefStatusStudi
    {
        public RefStatusStudi()
        {
            TblStudiLanjut = new HashSet<TblStudiLanjut>();
            TrRiwayatPendidikan = new HashSet<TrRiwayatPendidikan>();
        }

        public int IdRefSs { get; set; }
        public string Deskripsi { get; set; }

        public ICollection<TblStudiLanjut> TblStudiLanjut { get; set; }
        public ICollection<TrRiwayatPendidikan> TrRiwayatPendidikan { get; set; }
    }
}
