using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class RefRole
    {
        public RefRole()
        {
            TblRoleSubmenu = new HashSet<TblRoleSubmenu>();
        }

        public int IdRole { get; set; }
        public string Deskripsi { get; set; }
        public int? IdSistemInformasi { get; set; }

        public ICollection<TblRoleSubmenu> TblRoleSubmenu { get; set; }
    }
}
