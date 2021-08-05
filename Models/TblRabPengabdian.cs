using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblRabPengabdian
    {
        public TblRabPengabdian()
        {
            DtlRabPengabdian = new HashSet<DtlRabPengabdian>();
        }

        public int IdRabPengabdian { get; set; }
        public int IdProposal { get; set; }
        public int IdPengeluaranRab { get; set; }
        public decimal JumlahDana { get; set; }
        public decimal? Persentase { get; set; }

        public RefPengeluaranRab IdPengeluaranRabNavigation { get; set; }
        public ICollection<DtlRabPengabdian> DtlRabPengabdian { get; set; }
    }
}
