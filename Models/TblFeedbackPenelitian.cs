using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblFeedbackPenelitian
    {
        public int IdFeedback { get; set; }
        public int IdProposal { get; set; }
        public string Npp { get; set; }
        public string Feedback { get; set; }
        public DateTime? Tanggal { get; set; }
        public string Status { get; set; }
    }
}
