using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class RefKategoriKegiatanSister
    {
        public int id { get; set; }
        public int? parent_id { get; set; }
        public string nama { get; set; }

        public string message { get; set; }


    }
}
