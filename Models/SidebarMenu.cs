using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class SidebarMenu
    {
        public int urut { get; set; }
        public int menuid { get; set; }
        public int NO_URUT { get; set; }
        public string menuname { get; set; }
        public string menulocation { get; set; }
        public int parentid { get; set; }

        public List<SidebarMenu> ListMenu { get; set; }



    }
}
