using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblSistemInformasi
    {
        public TblSistemInformasi()
        {
            TblSiMenu = new HashSet<TblSiMenu>();
        }

        public int IdSistemInformasi { get; set; }
        public string NamaSi { get; set; }
        public string Server { get; set; }

        public ICollection<TblSiMenu> TblSiMenu { get; set; }
    }
}
