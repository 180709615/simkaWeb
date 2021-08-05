using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblDetailDp3
    {
        public int IdDetailDp3 { get; set; }
        public int? IdRefDp3 { get; set; }
        public decimal? Nilai { get; set; }

        public RefDp3 IdRefDp3Navigation { get; set; }
    }
}
