using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class Sister_DosenPenelitian
    {
        public Sister_DosenDetail dos { get; set; }
        public Penelitian pen { get; set; }
        public Pengabdian abdi { get; set; }
        public Pembicara bicara { get; set; }
        public Pengajaran ajar { get; set; }

        public Publikasi publi { get; set; }
        public MstKaryawan karyawan { get; set; }
    }
}
