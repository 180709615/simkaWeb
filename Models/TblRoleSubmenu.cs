using System;
using System.Collections.Generic;

namespace APIConsume.Models
{
    public partial class TblRoleSubmenu
    {
        public int IdSiSubmenu { get; set; }
        public int IdRole { get; set; }

        public RefRole IdRoleNavigation { get; set; }
        public TblSiSubmenu IdSiSubmenuNavigation { get; set; }
    }
}
