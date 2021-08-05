using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblSiSubmenu
    {
        public TblSiSubmenu()
        {
            TblRoleSubmenu = new HashSet<TblRoleSubmenu>();
        }

        public int IdSiSubmenu { get; set; }
        public int? IdSiMenu { get; set; }
        public string Deskripsi { get; set; }
        public bool? Isactive { get; set; }
        public string Link { get; set; }

        public TblSiMenu IdSiMenuNavigation { get; set; }
        public ICollection<TblRoleSubmenu> TblRoleSubmenu { get; set; }
    }
}
