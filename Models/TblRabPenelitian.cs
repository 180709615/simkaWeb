using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblRabPenelitian
    {
        public TblRabPenelitian()
        {
            DtlRabPenelitian = new HashSet<DtlRabPenelitian>();
        }

        public int IdRabPenelitian { get; set; }
        public int IdProposal { get; set; }
        public int IdPengeluaranRab { get; set; }
        public decimal JumlahDana { get; set; }
        public decimal? Persentase { get; set; }

        public RefPengeluaranRab IdPengeluaranRabNavigation { get; set; }
        public ICollection<DtlRabPenelitian> DtlRabPenelitian { get; set; }
    }
}
