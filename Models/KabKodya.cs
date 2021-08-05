using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class KabKodya
    {
        public decimal IdKabKodya { get; set; }
        public decimal? IdPropinsi { get; set; }
        public string NamaKabKodya { get; set; }

        public Propinsi IdPropinsiNavigation { get; set; }
    }
}
