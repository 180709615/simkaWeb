using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblSiMenu
    {
        public TblSiMenu()
        {
            TblSiSubmenu = new HashSet<TblSiSubmenu>();
        }

        public int IdSiMenu { get; set; }
        public int? IdSistemInformasi { get; set; }
        public string Deskripsi { get; set; }
        public bool? Isactive { get; set; }
        public string Link { get; set; }
        public int? NoUrut { get; set; }

        public TblSistemInformasi IdSistemInformasiNavigation { get; set; }
        public ICollection<TblSiSubmenu> TblSiSubmenu { get; set; }
    }
}
