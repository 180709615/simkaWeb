using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblPerpanjanganPenelitian
    {
        public int IdPerpanjangan { get; set; }
        public int IdProposal { get; set; }
        public int Ke { get; set; }
        public DateTime? TglMulaiPerpanjang { get; set; }
        public DateTime? TglSelesaiPerpanjang { get; set; }
        public DateTime? InsertDate { get; set; }
        public string IpAddress { get; set; }
        public string UserId { get; set; }
    }
}
