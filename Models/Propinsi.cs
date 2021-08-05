using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class Propinsi
    {
        public Propinsi()
        {
            KabKodya = new HashSet<KabKodya>();
        }

        public decimal IdPropinsi { get; set; }
        public string NamaPropinsi { get; set; }

        public ICollection<KabKodya> KabKodya { get; set; }
    }
}
